using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cry : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip cry;
    public void playButton()
    {
        audioSource.PlayOneShot(cry);
    }
}
