using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score2 : MonoBehaviour
{

    public Text Score;
    public static int scoreUp;

    void Update()
    {
        Score.text = "Score: " + scoreUp;
    }
}