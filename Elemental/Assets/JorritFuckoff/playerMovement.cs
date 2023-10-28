using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{   
    Rigidbody2D rg;
    public float horizontalMovement;
    public float verticalMovement;
    float speedX;
    float speedY;
    public Vector2 movement;
    public float maxSpeed = 8.0f; 

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalMovement = Input.GetAxisRaw("Vertical");
        horizontalMovement =  Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        speedX = horizontalMovement*9;
        speedY = verticalMovement*9;
        movement = new Vector2(speedX, speedY);
        rg.AddForce(movement);
        if (rg.velocity.magnitude > maxSpeed)
        {
            rg.velocity = rg.velocity.normalized * maxSpeed;
        }
    }
}