using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settingsScript : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void setVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }
}
