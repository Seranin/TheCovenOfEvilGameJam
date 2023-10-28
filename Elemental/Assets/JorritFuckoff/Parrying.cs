using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrying : MonoBehaviour
{
    public GameObject fireBalls;
    public Transform firePoint;
    public float fireForce = 20f;
    public float noParryTimer = 1.5f;
    public float parryCooldown = 1.5f;
    public float parryTime = 5.5f;
    public float sindsLastParry = 5f;
    private bool canParry = true; // Added a boolean flag to control parry availability

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        noParryTimer += Time.deltaTime;
        sindsLastParry += Time.deltaTime;
        if(noParryTimer>parryCooldown)
        {
            if (Input.GetMouseButtonDown(2))
            {
                Debug.Log("parry reset");
                sindsLastParry = 0;
                noParryTimer = 0;

            }
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log("euhhhh");
            if (sindsLastParry<=parryTime)
            {   
                Debug.Log("FUCK YOU ERIK!!!!!!!!");
                GameObject fireBall = Instantiate(fireBalls, firePoint.position, firePoint.rotation);
                fireBall.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

            }
    }
    /* private void OnTriggerStay2D(Collider2D other)
    {
            Debug.Log("euhhhh");
            if (sindsLastParry<=parryTime)
            {   
                Debug.Log("Fuck you Erik!!!!!!!!");
                GameObject fireBall = Instantiate(fireBalls, firePoint.position, firePoint.rotation);
                fireBall.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

            }
    } */
}
