using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class playerMovement : MonoBehaviour
{   
    Rigidbody2D rg;
    public float horizontalMovement;
    public float verticalMovement;
    public float speed = 8;
    public Vector2 movement;
    public Vector2 mousePosition;
    public Vector2 aimDirection;

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
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        //movement
        movement = new Vector2(horizontalMovement, verticalMovement).normalized;
        rg.velocity = new Vector2(movement.x*speed,movement.y*speed);
        //aiming
        aimDirection= mousePosition-rg.position;
        float aimAngle =Mathf.Atan2(aimDirection.y,aimDirection.x)*Mathf.Rad2Deg -90f;
        rg.rotation = aimAngle;
    }
}