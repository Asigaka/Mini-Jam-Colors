using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundsController
{
    public static void PlaySound(AudioClip audioClip)
    {
        GameObject soundObject = new GameObject(audioClip.name + " Sound");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
    }
}
