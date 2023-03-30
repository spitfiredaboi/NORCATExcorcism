using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class song : MonoBehaviour
{

    public AudioClip currentSong;
    public AudioSource source;
    public float songLength;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(PlaySong());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlaySong()
    {
        source.PlayOneShot(currentSong);
        yield return new WaitForSeconds(songLength);
        StartCoroutine(PlaySong());
    }
}
