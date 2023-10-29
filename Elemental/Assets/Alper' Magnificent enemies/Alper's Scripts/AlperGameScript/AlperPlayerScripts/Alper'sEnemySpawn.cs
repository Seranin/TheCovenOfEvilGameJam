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
            Vector3 SpawnPosition = transform.position;
            if( IsSpawnPointClear(SpawnPosition))
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
        
    }
    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawntime,maximumSpawnTime);
    }
    private bool IsSpawnPointClear(Vector3 spawnPosition)
{
    float radius = 1.0f; // Adjust this radius to suit your needs
    Vector3 checkPosition = spawnPosition + Vector3.up * 0.5f; // Ensure the check starts slightly above the spawn point
    return !Physics.CheckSphere(checkPosition, radius);
}

}
