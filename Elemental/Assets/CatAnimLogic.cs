using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimLogic : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public playerMovement playerMovement;
    private Vector2 dashvec;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("LeftClick");
        }
    }
    void LateUpdate()
    {
        if(Input.GetButton("Jump")){
            dashvec = playerMovement.movement * playerMovement.dashspeed;
            if(dashvec.y > dashvec.x)
            {
                if(dashvec.y >= 0){
                    anim.SetTrigger("DashUp");
                }
                else{
                    anim.SetTrigger("DashDown");
                }
            }
            else{
                if(dashvec.x >= 0)
                {
                    anim.SetTrigger("DashRight");
                }
                else{
                    anim.SetTrigger("Dashleft");
                }
            }
        }
    }
}
