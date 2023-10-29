/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightEnemyShoot : MonoBehaviour
{
    public Transform EnemyGunOffSet;
    public  GameObject EnemyChargePrefab;
    public  GameObject EnemyBulletPrefab;
    public float EnemyBulletSpeed;
     private Vector2 TargetDirection;
    private GameObject player;
    public float ShootDistance = 8 ;
    public float TimeToShootAgain = 8;
    public float EnemyShootRate = 9;
    public float ChargeUpTime = 9;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( ChargeUpTime> 1.5)
        {TargetDirection = (player.transform.position - transform.position).normalized;}
    }
    void FixedUpdate()
    {
        CheckDistance();
        TimeToShootAgain += Time.deltaTime;
        ChargeUpTime += Time.deltaTime;
        
    }
    private void CheckDistance()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= ShootDistance && TimeToShootAgain >= EnemyShootRate)
        {
            ChargeupF();
            
        }
        if(ChargeUpTime >= 1 && ChargeUpTime <= 1.2)
        {
            Shoot();
        }
        
    }
    private void ChargeupF()
    {   
           Debug.Log("Fuckkkkkk");
            GameObject Chargeup = Instantiate(EnemyChargePrefab,EnemyGunOffSet.position,transform.rotation);
            Rigidbody2D rigidbody = Chargeup.GetComponent<Rigidbody2D>();
            rigidbody.velocity = EnemyBulletSpeed * transform.up;
            ChargeUpTime = 0;

       
    
    }
    private void Shoot()
    {   Debug.Log("Shoot ya facker");
        GameObject EnemyAttack = Instantiate(EnemyBulletPrefab,EnemyGunOffSet.position,transform.rotation);
        Rigidbody2D rigidbody = EnemyAttack.GetComponent<Rigidbody2D>();
        rigidbody.velocity = EnemyBulletSpeed * transform.up;
        TimeToShootAgain=0;
    }
}

 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightEnemyShoot : MonoBehaviour
{
    public Transform EnemyGunOffSet;
    public  GameObject EnemyBeamPrefab;
    public  GameObject EnemyChareUpBeamPrefab;
    public float EnemyBulletSpeed =1;
    private Vector2 TargetDirection;
    private GameObject player;
    public float ShootDistance = 40;
    public float TimeToShootAgain;
    public float EnemyShootRate;
    public float chargeUp = 6;
    public Vector2 lastPlayerPosition;
    public float firstChargHit = 1;
    public float LastChargeHit = 1.5f;
    public bool didntshoot= true;
    public Quaternion savedRotation;
    public static bool isCharging = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        EnemyShootRate = 8;
    }

    // Update is called once per frame
    void Update()
    {
        TargetDirection = (player.transform.position - transform.position).normalized;
        if(chargeUp> firstChargHit)
        {
            Debug.Log(" he goes into the firtst if");
            
            if(chargeUp< LastChargeHit)
            {    
                Debug.Log(" he goes into shoot normaly");
                Shoot();
            }
        }
    }
    void FixedUpdate()
    {
        
        if(chargeUp > 1.5)
        {
            CheckDistance();
            TimeToShootAgain += Time.deltaTime;
        }
        chargeUp += Time.deltaTime;
        

        
    }
    private void CheckDistance()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= ShootDistance)
        {
            Charge();
            
        }
        
    }
    public void Charge()
    {
        if(TimeToShootAgain >= EnemyShootRate)
       {
        lastPlayerPosition = EnemyGunOffSet.position;
        savedRotation = transform.rotation;
        
        GameObject EnemyBullet = Instantiate(EnemyChareUpBeamPrefab,EnemyGunOffSet.position,transform.rotation);
        chargeUp = 0;
        TimeToShootAgain= 0;
        didntshoot = true;
        isCharging= true;
       }
    }
    public void Shoot()
    {
        if (didntshoot)
        {
            GameObject EnemyBullet = Instantiate(EnemyBeamPrefab,lastPlayerPosition,savedRotation);   
            didntshoot= false;
            isCharging= false;
        }
         
    }
}
