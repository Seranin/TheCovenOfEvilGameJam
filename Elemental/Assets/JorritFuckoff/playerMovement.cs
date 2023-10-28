using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{   
    Rigidbody2D rg;
    public float horizontalMovement;
    public float verticalMovement;
    public float speed = 8;
    public Vector2 movement;


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
        movement = new Vector2(horizontalMovement, verticalMovement).normalized;
        rg.velocity = new Vector2(movement.x*speed,movement.y*speed);
        
    }
}