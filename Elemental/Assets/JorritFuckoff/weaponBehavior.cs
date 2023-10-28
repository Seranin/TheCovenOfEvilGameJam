using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponBehavior : MonoBehaviour
{
    public GameObject fireBalls;
    public Transform firePoint;
    public float fireForce = 20f;
    // Start is called before the first frame update
   public void Fire()
   {
        GameObject fireBall = Instantiate(fireBalls,firePoint.position, firePoint.rotation);
        fireBall.GetComponent<Rigidbody2D>().AddForce(firePoint.up*fireForce,ForceMode2D.Impulse);
   }
}
