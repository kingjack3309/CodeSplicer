using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    void SetNewVolume()
    {
        foreach (GameObject game_object in GameObject.FindGameObjectsWithTag("Has Audio"))
        {
            game_object.GetComponent<SetVolume>().UpdateVolume();                                                                                                                                                                                                           
        }

        foreach (GameObject game_object in GameObject.FindGameObjectsWithTag("Player"))
        {
            game_object.GetComponent<SetVolume>().UpdateVolume();
        }
    }

    public void ChangeSfxVolume()
    {
        settingsData.SetSFXVolume(gameObject.GetComponent<Slider>().value);

        SetNewVolume();
    }

    public void ChangeMusicVolume()
    {
        settingsData.SetMusicVolume(gameObject.GetComponent<Slider>().value);

        SetNewVolume();
    }

    public void ChangeCutsceneVolume()
    {
        settingsData.SetCutsceneVolume(gameObject.GetComponent<Slider>().value);

        SetNewVolume();
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
