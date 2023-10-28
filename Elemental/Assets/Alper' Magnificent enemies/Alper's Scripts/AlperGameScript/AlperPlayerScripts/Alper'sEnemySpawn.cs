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
    private float minimumSpawntime;
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
            int Type = Random.Range(1,6);
            if(Type <= 5)
            {
                Instantiate(ZombiePref,transform.position,Quaternion.identity);
                SetTimeUntilSpawn();
            }
            else
            {
                Instantiate(BrandPref,transform.position,Quaternion.identity);
                SetTimeUntilSpawn(); 

            }
                    

            
                
        }
        
    }
    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawntime,maximumSpawnTime);
    }
}
