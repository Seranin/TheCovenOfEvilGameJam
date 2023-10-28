using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlperEnemyBullet : MonoBehaviour
{
    public float life = 1.5f;
    public EnemyLogic enemyLogic;
    public GameObject enemy;
    public float damage = 10;
    void Start()
    {
         Destroy(gameObject,life);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D  (Collision2D collision)
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
}
