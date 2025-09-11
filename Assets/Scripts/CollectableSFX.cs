using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSFX : MonoBehaviour
{

    [Header("------Audio Clips------")]

    public AudioClip coinCollected;
    //public AudioClip foodCollected;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem"))
        {
            audioSource.clip = coinCollected;
            audioSource.Play();
        }
    }
}
