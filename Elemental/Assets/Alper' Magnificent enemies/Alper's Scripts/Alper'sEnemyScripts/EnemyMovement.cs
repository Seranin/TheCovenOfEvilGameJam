using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float rotation;
    private Rigidbody2D rigidbody;
    private Vector2 TargetDirection;
    private Transform player;
    void Awake()
    {
        player = FindObjectOfType<>
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }
    private void UpdateTargetDirection()
    {
        TargetDirection = 
    }
    private void RotateTowardsTarget()
    {

    }
    private void SetVelocity()
    {

    }
}
