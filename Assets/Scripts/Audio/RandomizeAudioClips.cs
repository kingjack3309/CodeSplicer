using UnityEngine;
using System.Collections.Generic;

public class RandomizeAudioClips : MonoBehaviour
{

    public List<AudioClip> audioClips = new List<AudioClip>();

    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int result = Random.Range(0, 9);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[result];
        audioSource.Play();
    }
}
