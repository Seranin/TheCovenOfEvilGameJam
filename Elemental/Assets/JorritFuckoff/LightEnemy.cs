using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightEnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationspeed;
    [SerializeField]
    private float Distance = 5.0f;
    private Rigidbody2D rb;
    private Vector2 TargetDirection;
    private GameObject player;
    void Awake()
    {
    
        rb =  GetComponent<Rigidbody2D>();
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
        float aimAngle =Mathf.Atan2(TargetDirection.y,TargetDirection.x)*Mathf.Rad2Deg -90f;
        rb.MoveRotation(aimAngle);
        
        //transform.rotation.SetEulerRotation
        //Quaternion targetRotaion = Quaternion.LookRotation(transform.right,TargetDirection);
        //Quaternion rotation = Quaternion.RotateTowards(transform.rotation,targetRotaion, rotationspeed * Time.deltaTime);
        //rigidbody.SetRotation(rotation);
    }
    private void SetVelocity()
    {
        rb.velocity = transform.up * speed;
    }
   private void CheckDistance()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= Distance)
        {
            rb.velocity = Vector2.zero; // Stop the enemy when close to the player.
        }
    }
}