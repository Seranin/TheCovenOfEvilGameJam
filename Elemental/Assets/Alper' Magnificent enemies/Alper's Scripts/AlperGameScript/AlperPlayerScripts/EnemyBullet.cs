using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float EnemyLife = 3.0f;
    void Awake()
    {
        Destroy(gameObject,EnemyLife);
    }
    private void OnTriggerEnter2D (Collider2D other)
    {
        if(other.GetComponent<playerMovement>())
        {
            Destroy(gameObject); 
        }

        if(other.GetComponent<Parrying>() && Parrying.isParrying)
        {
            Destroy(gameObject); 
        }
    }
     private void OnCollisionEnter2D  (Collision2D collision)
    {

        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.GetComponent<Parrying>() && Parrying.isParrying)
        {
            Destroy(gameObject); 
        }
    }
    
}
