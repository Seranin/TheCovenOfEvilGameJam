using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlpersEnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject TablePref1;
     [SerializeField]
    private GameObject LuxPref;

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
            int Type = UnityEngine.Random.Range(1,101);
            if( Type >= 96 )
            {
                Instantiate(TablePref1,transform.position,Quaternion.identity);
                

            }
            else if(Type >= 81 )
            {
                Instantiate(LuxPref,transform.position,Quaternion.identity);
            }
            else if( Type > 50)
            {
                Instantiate(BrandPref,transform.position,Quaternion.identity);
            }
            else
            {
                Instantiate(ZombiePref,transform.position,Quaternion.identity);
            }
            SetTimeUntilSpawn();    
        }
        
    }
    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawntime,maximumSpawnTime);
    }
}
