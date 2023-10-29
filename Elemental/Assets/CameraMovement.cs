using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerPos;
    public float lerpStr = 5f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = playerPos.position + new Vector3(0, 0, -10f);
        Vector3 target = playerPos.position + new Vector3(0, 0, -15f);
        transform.position =  Vector3.Lerp(transform.position, target, Time.deltaTime * lerpStr);
    }
}
