using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlpersEnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject ZombiePref;
    private GameObject BrandPref;
    [SerializeField]
    private float minimuSpawntime;
    [SerializeField]
    private float maximumSpawnTime;

    private float _timeUntilSpawn ;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
