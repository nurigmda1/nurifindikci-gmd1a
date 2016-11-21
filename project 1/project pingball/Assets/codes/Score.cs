using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "bumper")
        {
            Score2.scoreUp+= 10;
        }
    }
}
