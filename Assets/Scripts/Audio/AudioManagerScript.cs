using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{

    [Header("------Audio Sources------")]

    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource SFXSource2;
    [SerializeField] AudioSource MusicSource;

    [Header("------Audio Clips------")]

    public AudioClip walking;
    public AudioClip music;
    public AudioClip windGust;

    private void Start()
    {
        MusicSource.clip = music;
        MusicSource.Play();

        SFXSource.clip = walking;
        SFXSource.Play();

        SFXSource2.clip = windGust;
        SFXSource2.Play();
    }

}
