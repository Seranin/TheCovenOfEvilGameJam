using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlpersEnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject ZombiePref;
    [SerializeField]
    private GameObject BrandPref;
    [SerializeField]
    private float minimuSpawntime;
    [SerializeField]
    private float maximumSpawnTime;

    private float timeUntilSpawn ;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
            timeUntilSpawn -= Time.deltaTime;
            if(timeUntilSpawn <= 0)
            {
                int UnitType = Random.Range(1,6);
                if(UnitType <= 3)
                {
                    Instantiate(ZombiePref,transform.position,Quaternion.identity);
                    
                }
                else if(3 < UnitType && UnitType <= 5)
                {
                    Instantiate(BrandPref,transform.position,Quaternion.identity); 
                }
            }
            SetTimeUntilSpawn();
    }
    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimuSpawntime,maximumSpawnTime);
    }
}
