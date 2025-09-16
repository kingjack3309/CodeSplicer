using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CenematicTriggerScript : MonoBehaviour
{

    [SerializeField] GameObject Background2;
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip transition;
    public AudioClip transitionTwo;
    public AudioClip matches;

    public BoxCollider2D triggerCollider;

    private void Start()
    {
        triggerCollider = GetComponent<BoxCollider2D>();
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
        }
    }

    private void Update()
    {
        if (SFXSource.clip == transition && !SFXSource.isPlaying)
        {
            SFXSource.clip = transitionTwo;
            SFXSource.Play();
        }

        if (SFXSource.clip == transitionTwo && !SFXSource.isPlaying)
        {
            SFXSource.clip = matches;
            SFXSource.Play();
        }

        if (SFXSource.clip == matches && !SFXSource.isPlaying)
        {
            SceneManager.LoadScene("Tutorial Scene");
        }
    }

}
