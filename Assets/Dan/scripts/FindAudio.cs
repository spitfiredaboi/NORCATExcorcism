using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioListener[] audiolist = GameObject.FindObjectsOfType<AudioListener>(); 

        foreach(AudioListener al in audiolist )
        {
            Debug.Log(al.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
