using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyShoot : MonoBehaviour
{
    public Transform EnemyGunOffSet;
    public  GameObject EnemyBulletPrefab;
    public float EnemyBulletSpeed;
     private Vector2 TargetDirection;
    private GameObject player;
    public float ShootDistance;
    public float TimeToShootAgain;
    public float EnemyShootRate = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        EnemyShootRate = 1;
    }

    // Update is called once per frame
    void Update()
    {
         TargetDirection = (player.transform.position - transform.position).normalized;
    }
    void FixedUpdate()
    {
        CheckDistance();
        TimeToShootAgain += Time.deltaTime;
        
    }
    private void CheckDistance()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= ShootDistance)
        {
            Shoot();
            
        }
        
    }
    private void Shoot()
    {
       if(TimeToShootAgain >= EnemyShootRate)
       {
        GameObject EnemyBullet = Instantiate(EnemyBulletPrefab,EnemyGunOffSet.position,transform.rotation);
        Rigidbody2D rigidbody = EnemyBullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = EnemyBulletSpeed * transform.up;
        TimeToShootAgain = 0;
       }
       

    }
}
