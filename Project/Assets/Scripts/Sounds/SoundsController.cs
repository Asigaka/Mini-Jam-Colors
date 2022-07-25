using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    public static SoundsController Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    public void PlaySound(AudioClip audioClip)
    {
        GameObject soundObject = new GameObject(audioClip.name + " Sound");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
        Destroy(soundObject, audioClip.length);
    }
}
