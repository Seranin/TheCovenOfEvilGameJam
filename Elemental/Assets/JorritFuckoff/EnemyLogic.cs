using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public  GameObject MilkPref;
    private GameObject bullet;
    public float hp = 30;
    public float damagetaken = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void dealDamage(float damagetaken){
        hp-= damagetaken;
        

    }
    private void OnCollisionEnter2D  (Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet"){
            bullet = collision.gameObject;
            Debug.Log("hqahdufjdgf");
            dealDamage(damagetaken);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if(hp <= 0 )
        {   
            float score = 5*ScoreScript.multiplier;
            int DropMilk = UnityEngine.Random.Range(1,101);
            if(DropMilk >= 90)
            {
                Instantiate(MilkPref,transform.position,Quaternion.identity);
            }
            Destroy(gameObject);
            ScoreScript.killCount += 1; 
            ScoreScript.scoreValue +=score;
        } 
    }
        
    
}
