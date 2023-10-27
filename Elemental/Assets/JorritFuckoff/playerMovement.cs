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
    Vector2 movement;
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
        speedX = horizontalMovement;
        speedY = verticalMovement;
        movement = new Vector2(speedX, speedY);
        rg.AddForce(movement);
        // if(rg.velocity.magnitude >= 5){
        //     rg.velocity.magnitude.
        // }
    }
}
