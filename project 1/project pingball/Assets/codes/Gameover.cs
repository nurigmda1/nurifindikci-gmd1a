using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Gameover : MonoBehaviour {
    public GameObject pinball;
    public GameObject teleport;
    public int levens;
    public GameObject panel; 
    public void OnTriggerEnter(Collider collider)
      
    {
        pinball.SetActive(false);
        pinball.transform.position = teleport.transform.position;
        pinball.SetActive(true);
        levens -= 1;
        if(levens==3)
        {
            panel.SetActive(true);
            Time.timeScale = 0;



        }
    }
    
        // Use this for initialization
	void Start () {
        levens = 5;
        panel.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {

}
public void tryagian()
    {
        SceneManager.LoadScene("pingball");
    } 
}


