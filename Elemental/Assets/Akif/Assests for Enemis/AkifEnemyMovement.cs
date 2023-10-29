using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkifEnemyMovement: MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationspeed;
    private Rigidbody2D rigidbody;
    private Vector2 TargetDirection;
    private GameObject player;
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
}
