using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.GetComponent<Parrying>() && Parrying.isParrying)
        {
            Destroy(gameObject); 
        }
    }
}

