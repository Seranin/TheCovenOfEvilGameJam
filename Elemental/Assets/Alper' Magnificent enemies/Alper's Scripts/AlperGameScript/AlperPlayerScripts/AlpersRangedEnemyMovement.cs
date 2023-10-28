using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationspeed;
    [SerializeField]
    private float Distance = 5.0f;
    private float DistanceShoot = 8.0f;
    private float timetofire;
    public float fireRate = 2;
    
    private Rigidbody2D rigidbody;
    private Vector2 TargetDirection;
    private GameObject player;
    private GameObject EnemyBullet;
    private Transform EnemyFirePoint;
    public float bulletforce = 15f;
    void Awake()
    {
    
        rigidbody =  GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    void Update()
    {
        TargetDirection = (player.transform.position - transform.position).normalized;

    }

    private void FixedUpdate()
    {
        RotateTowardsTarget();
        SetVelocity();
        CheckDistance();

    }
    private void RotateTowardsTarget()
    {
        //transform.LookAt(player.transform);
        transform.up = TargetDirection;
        //transform.rotation.SetEulerRotation
        //Quaternion targetRotaion = Quaternion.LookRotation(transform.right,TargetDirection);
        //Quaternion rotation = Quaternion.RotateTowards(transform.rotation,targetRotaion, rotationspeed * Time.deltaTime);
        //rigidbody.SetRotation(rotation);
    }
    private void SetVelocity()
    {
        rigidbody.velocity = transform.up * speed;
    }
   private void CheckDistance()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= Distance)
        {
            rigidbody.velocity = Vector2.zero; // Stop the enemy when close to the player.
            
        }
        if(distanceToPlayer <= DistanceShoot)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if(timetofire <= 0)
        {
            Debug.Log("Shoot");
            timetofire = fireRate;

        }else
        {
            timetofire -= Time.deltaTime;
        }

    }
}
