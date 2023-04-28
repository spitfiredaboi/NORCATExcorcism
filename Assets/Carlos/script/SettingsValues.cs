using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsValues : MonoBehaviour
{
    public static float volume = 100;

    public static void SetVolume()
    {
        AudioMixer audioMixer = GameObject.FindObjectOfType<AudioMixer>();
        if (audioMixer != null)
        {
            audioMixer.SetFloat("volume", volume);
        }
    }
}
