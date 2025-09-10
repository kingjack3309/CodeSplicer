using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenematicTriggerScript : MonoBehaviour
{

    [SerializeField] GameObject Background2;
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip transition;
    public AudioClip transitionTwo;
    public AudioClip matches;

    public BoxCollider2D collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Background2.gameObject.SetActive(true);
            
            MusicSource.Stop();
            SFXSource.Stop();

            SFXSource.clip = transition;
            SFXSource.Play();

            //timer

            SFXSource.clip = transitionTwo;
            SFXSource.Play();
        }
    }
}
