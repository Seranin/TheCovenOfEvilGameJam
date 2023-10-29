using System.Collections;
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
    public weaponBehavior weapon;
    public float noDashTimer = 2.0f;
    public float dashCooldown = 2.0f;
    public float dashspeed = 8.0f;
    public Vector2 dashVector = Vector2.zero;
    public bool dashing = false ;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        dashing = false;
        verticalMovement = Input.GetAxisRaw("Vertical");
        horizontalMovement =  Input.GetAxisRaw("Horizontal");
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        { 
            weapon.Fire();
        }
        noDashTimer += Time.deltaTime;       
        
        dashVector = Vector2.zero;
        if(Input.GetButton("Jump"))
        {
             
            if (noDashTimer >= dashCooldown)
            {
                dashVector = movement * dashspeed;
                rg.MovePosition(rg.position + new Vector2(movement.x*5,movement.y*5));
                noDashTimer = 0;
                dashVector = Vector2.zero;
                Debug.Log("hfbdjjn");
                dashing = true;
            }
        } 
    }

    void FixedUpdate()
    {
        if(!dashing){
        //movement
        movement = new Vector2(horizontalMovement, verticalMovement).normalized;
        rg.velocity = new Vector2(movement.x,movement.y)*speed;
        //aiming
        aimDirection= mousePosition-rg.position;
        float aimAngle =Mathf.Atan2(aimDirection.y,aimDirection.x)*Mathf.Rad2Deg -90f;
        rg.MoveRotation(aimAngle);
        }
        
        
        
        
    }
}