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
    }

    public void UpdateVolume()
    {
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
    }
}
