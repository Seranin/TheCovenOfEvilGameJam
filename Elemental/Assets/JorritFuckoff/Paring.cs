using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paring : MonoBehaviour
{
    public GameObject fireBalls;
    public Transform firePoint;
    public float fireForce = 20f;
    private bool canParry = true; // Added a boolean flag to control parry availability

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2) && canParry)
        {
            StartCoroutine(Parry());
        }
    }

    IEnumerator Parry()
    {   canParry = true;
        yield return new WaitForSeconds(0.5f); // Parry duration
         canParry = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canParry && other.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
            GameObject fireBall = Instantiate(fireBalls, firePoint.position, firePoint.rotation);
            fireBall.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        }
    }
}
