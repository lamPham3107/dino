using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        PlayHomeSound();

    }
    public AudioClip backgroundMusic;
    public AudioClip gameoverMusic;
    public AudioClip homeSound;
    private AudioSource audioSource;
    public void PlayBackgroundSound()
    {
        if (backgroundMusic != null && audioSource != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    public void PlayHomeSound()
    {
        if (homeSound != null && audioSource != null)
        {
            audioSource.clip = homeSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    public void PlayGameOverSound()
    {
        if (gameoverMusic != null && audioSource != null)
        {
            audioSource.clip = gameoverMusic;
            audioSource.loop = false;
            audioSource.Play();
        }
    }
    public void StopSound()
    {
        if (audioSource != null)
            audioSource.Stop();
    }


}
