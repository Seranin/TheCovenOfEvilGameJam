using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float EnemyLife = 2.0f;
    void Awake()
    {
        Destroy(gameObject,EnemyLife);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<playerMovement>())
        {
            Destroy(gameObject); 
        }
    }
}
