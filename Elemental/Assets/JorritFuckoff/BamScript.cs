using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamScript : MonoBehaviour
{
    public float timeToLive = 0.5f;
    public float TimeLived;
    // Start is called before the first frame update
    void Start()
    {
        TimeLived= 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLived += Time.deltaTime;
        if (TimeLived >= timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
