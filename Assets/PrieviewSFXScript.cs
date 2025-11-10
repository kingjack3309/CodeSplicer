using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrieviewSFXScript : MonoBehaviour
{
    AudioSource audioSource;

    AudioClip clip;

    public List<AudioClip> sfxClipList;

    public List<AudioClip> cutsceneClipList;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clip = GetComponent<AudioClip>();
    }

    public void PreviewSFX()
    {
        clip = sfxClipList[Random.Range(0, sfxClipList.Count)];
        audioSource.Play();
    }

    public void PreviewCutscene()
    {
        clip = cutsceneClipList[Random.Range(0, cutsceneClipList.Count)];
        audioSource.Play();
    }
}
