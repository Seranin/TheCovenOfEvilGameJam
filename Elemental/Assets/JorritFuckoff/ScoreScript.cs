using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static float scoreValue = 0;
    public static float multiplier = 1;
    public static int killCount = 0;
    //Text score;
    // Start is called before the first frame update
    void Start()
    {
        //score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {   
        //score.text = "Score: " + scoreValue;
        Debug.Log(scoreValue);
        if (killCount ==5){
            multiplier +=0.1f;
            killCount =0;
        }
    }
}
