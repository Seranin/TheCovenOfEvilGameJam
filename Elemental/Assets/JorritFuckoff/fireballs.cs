using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballs : MonoBehaviour
{
    public float life = 1.5f;
    public EnemyLogic enemyLogic;
    public GameObject enemy;
    public float damage = 10;
    void Awake()
    {
        Destroy(gameObject,life);
    }
    private void OnCollisionEnter2D  (Collision2D collision)
    {
        Destroy(gameObject);
        
    }

}
