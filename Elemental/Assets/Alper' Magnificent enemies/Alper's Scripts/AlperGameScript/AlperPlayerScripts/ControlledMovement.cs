using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Vector2 movementInput;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigidbody.velocity = movementInput;
    }
    private void OnMove(InputValue inputValue )
    {
        movementInput = inputValue.Get<Vector2>();
    }
}

