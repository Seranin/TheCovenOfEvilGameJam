using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static float scoreValue = 0;
    public static float multiplier = 1;
    public static int killCount = 0;
    public float testmulti =multiplier;
    public float checkChange =0;
    //Text score;
    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        killCount = 0;
        //score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {   if(scoreValue > checkChange)
    {
        Debug.Log(scoreValue);
        if (killCount%5 ==0 && killCount!= 0){
            multiplier +=0.2f;
        }
    }
        //score.text = "Score: " + scoreValue;
        
        checkChange = scoreValue;
    }
}
