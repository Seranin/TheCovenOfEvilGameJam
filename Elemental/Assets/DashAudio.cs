using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAudio : MonoBehaviour
{
    AudioSource Source;
    // Start is called before the first frame update
    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump")){
            if(!Source.isPlaying)
            {
                Source.Play();
            }
        }
    }
}


