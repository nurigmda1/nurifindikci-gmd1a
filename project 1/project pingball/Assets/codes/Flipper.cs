using UnityEngine;
using System.Collections;


public class Flipper : MonoBehaviour
{
    public float maxAngle1 = -20.0f; //maximale hoek die gemaakt kan worden door de flipper
    public float flipTime1 = 0.1f; //snelheid waarme de flipper draait... hoe lager waarde hoe sneller
    public string buttonName1 = "Fire1"; //(mouse)button for activation flipper rotation
    public bool bol1; //for activation flipper collision
    private Quaternion initialOrientation1; //begin punt voordat de hoek gemaakt word
    private Quaternion finalOrientation1; //de hoek die gemaakt word
    private float t1; //rotatie op stilstaand moment van (draaiend) object
    public Vector3 direction; //directie voor collision
    public Rigidbody ball; //GameObject > bal
    public float force = -150; //snelheid waarmee bal wegschiet
                               // Use this for initialization
    void Start()
    {
        initialOrientation1 = transform.rotation; //begin waarden van (rotation) object = begin initialOrientation
        finalOrientation1.eulerAngles = new Vector3(initialOrientation1.eulerAngles.x, initialOrientation1.eulerAngles.y + maxAngle1, initialOrientation1.eulerAngles.z); //eindwaarde van object na (beginwaarde rotatie x-as, beginwaarde rotatie y-as + maximale draaihoek[in dit geval nodig op y-as voor de juiste hoek kan verschillen bij andere projecten], beginwaarde rotatie z-as)
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(buttonName1))//buttonName1 = de knop die je indrukt
        {
            transform.rotation = Quaternion.Slerp(initialOrientation1, finalOrientation1, t1 / flipTime1);//verandering rotatie object door middel van begin rotatie , eindrotatie, stilstaand punt en snelheid 
            t1 += Time.deltaTime; //stilstaand punt + snelheid van berekenen frames per sec
            if (t1 > flipTime1) //als stilstaand punt groter is dan snelheid...
            {
                t1 = flipTime1;//stilstaand punt word veranderd naar eind punt
            }
        }
        else
        {
            transform.rotation = Quaternion.Slerp(initialOrientation1, finalOrientation1, t1 / flipTime1);
            t1 -= Time.deltaTime;
            if (t1 < 0)//als stilstaand punt kleiner is dan 0....
            {
                t1 = 0;//stilstaand punt is dan weer bij begin
            }
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (Input.GetButton(buttonName1))
        {
            bol1 = true;//als knop is ingedrukt bool zet collision op true
            direction = collision.contacts[0].point;//terugkaatsende richting tijdens collision veroorzaken
            ball.AddForce(direction * force);//de snelheid waarme de bal terugkaatst
        }
    }
}

