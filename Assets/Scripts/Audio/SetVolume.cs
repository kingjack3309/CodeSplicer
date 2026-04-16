using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    public SettingsDataManager settingsData;

    AudioSource audioSource;

    public bool sfxSource = false;
    public bool musicSource = false;
    public bool cutsceneSource = false;
    public bool enemySFX = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (sfxSource)
        {
            audioSource.volume = settingsData.sfxVolume;
        }

        else if (musicSource)
        {
            audioSource.volume = settingsData.musicVolume;
        }

        else if (cutsceneSource)
        {
            audioSource.volume = settingsData.cutsceneVolume;
        }
        else if (enemySFX)
        {
            audioSource.volume = settingsData.enemyVolume;
        }
    }

    public void UpdateVolume()
    {
        if (sfxSource)
        {
            if (audioSource != null && settingsData != null)
            {
                audioSource.volume = settingsData.sfxVolume;
            }
        }
        else if (musicSource)
        {
            if (audioSource != null && settingsData != null)
            {
                audioSource.volume = settingsData.musicVolume;
            }
        }
        else if (cutsceneSource)
        {
            if (audioSource != null && settingsData != null)
            {
                audioSource.volume = settingsData.cutsceneVolume;
            }
        }
        else if (enemySFX)
        {
            if (audioSource != null && settingsData != null)
            {
                audioSource.volume = settingsData.enemyVolume;
            }
        }
    }
}
