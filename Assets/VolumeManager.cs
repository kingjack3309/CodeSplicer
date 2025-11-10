using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public SettingsDataManager settingsData;

    public bool sfx = false;
    public bool music = false;
    public bool cutscene = false;

    private void Start()
    {
         if (sfx)
            {
                SetSFXVolume();
            }
        else if (music)
        {
            SetMusicVolume();
        }

        else if (cutscene)
        {
            SetCutsceneVolume();
        }
    }

    public void ChangeSfxVolume()
    {
        settingsData.SetSFXVolume(gameObject.GetComponent<Slider>().value);

        GameObject.FindWithTag("Has Audio").GetComponent<SetVolume>().UpdateVolume();
    }

    public void ChangeMusicVolume()
    {
        settingsData.SetMusicVolume(gameObject.GetComponent<Slider>().value);

        GameObject.FindWithTag("Has Audio").GetComponent<SetVolume>().UpdateVolume();
    }

    public void ChangeCutsceneVolume()
    {
        settingsData.SetCutsceneVolume(gameObject.GetComponent<Slider>().value);

        GameObject.FindWithTag("Has Audio").GetComponent<SetVolume>().UpdateVolume();
    }

    void SetSFXVolume()
    {
        gameObject.GetComponent<Slider>().value = settingsData.sfxVolume;
    }

    void SetMusicVolume()
    {
        gameObject.GetComponent<Slider>().value = settingsData.musicVolume;
    }

    void SetCutsceneVolume()
    {
        gameObject.GetComponent<Slider>().value = settingsData.cutsceneVolume;
    }
}
