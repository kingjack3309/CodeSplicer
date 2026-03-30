using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerScript : MonoBehaviour
{
    AudioSource audioSuorce;
    BoxCollider2D boxCollider;

    private void Start()
    {
        audioSuorce = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSuorce.Play();
            boxCollider.enabled = false;
        }
    }
}
