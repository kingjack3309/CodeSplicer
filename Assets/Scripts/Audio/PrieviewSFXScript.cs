using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrieviewSFXScript : MonoBehaviour
{
    AudioSource audioSource;

    AudioClip clip;

    public List<AudioClip> sfxClipList;

    public List<AudioClip> enemyClipList;

    public List<AudioClip> cutsceneClipList;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PreviewSFX()
    {
        clip = sfxClipList[Random.Range(0, sfxClipList.Count)];
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PreviewCutscene()
    {
        clip = cutsceneClipList[Random.Range(0, cutsceneClipList.Count)];
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PreviewEnemySFX()
    {
        clip = enemyClipList[Random.Range(0, enemyClipList.Count)];
        audioSource.clip = clip;
        audioSource.Play();
    }
}
