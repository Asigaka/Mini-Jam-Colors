using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundsController : MonoBehaviour
{
    [SerializeField] private AudioClip mainMenu;
    [SerializeField] private AudioClip firstBattle;
    [SerializeField] private AudioClip secondBattle;

    public static SoundsController Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerMusic(mainMenu, false);
        }
        else
        {
            int i = Random.Range(0, 2);

            if (i == 0)
            {
                PlayerMusic(secondBattle, true);
            }
            else
            {
                PlayerMusic(firstBattle, true);
            }
        }
    }

    public void PlayOneShotSound(AudioClip audioClip)
    {
        GameObject soundObject = new GameObject(audioClip.name + " Sound");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
        Destroy(soundObject, audioClip.length);
    }

    public void PlayerMusic(AudioClip audioClip, bool loop)
    {
        GameObject soundObject = new GameObject(audioClip.name + " Sound");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.loop = loop;
        audioSource.clip = audioClip;
        audioSource.Play();
        //Destroy(soundObject, audioClip.length);
    }
}
