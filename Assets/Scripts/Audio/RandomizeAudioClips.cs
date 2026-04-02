using UnityEngine;
using System.Collections.Generic;

public class RandomizeAudioClips : MonoBehaviour
{

    public List<AudioClip> audioClips = new List<AudioClip>();

    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int result = Random.Range(1, 10);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[result];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
