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
    public float parryTime = 0.5f;
    public float sindsLastParry = 5f;
    public bool canParry = true; // Added a boolean flag to control parry availability
    public static bool isParrying = false;
    private int count = 0;
    private int countparry = 0;
    public bool parryBool = false;

    public List<Collider2D> colliderList = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        noParryTimer += Time.deltaTime;
        sindsLastParry += Time.deltaTime;
        if(sindsLastParry>parryTime)
        {
            isParrying = false;
            colliderList = new List<Collider2D>();
        }
        if(noParryTimer>parryCooldown)
        {   
            Debug.Log("reee");
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("parry reset");
                sindsLastParry = 0;
                noParryTimer = 0;
                isParrying = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        // count+=1;
        // Debug.Log(count);
        if (isParrying && other.gameObject.tag == "EnemyBullet")
        {   
            Debug.Log("pain");
            if (!colliderList.Contains(other))
            {
                //input hit sound
                Debug.Log("Fuck you Akif im not changing it again!!!!!!!!");
                GameObject fireBall = Instantiate(fireBalls, firePoint.position, firePoint.rotation);
                fireBall.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
                colliderList.Add(other);
            }
            
            
            
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
