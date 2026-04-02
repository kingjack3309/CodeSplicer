using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSettingsData", menuName = "settings data")]
public class SettingsDataManager : ScriptableObject
{
    public float sfxVolume = 0.5f;
    public float musicVolume = 0.5f;
    public float cutsceneVolume = 0.5f;
    public float enemyVolume = 0.75f;

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
    }
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
    }
    public void SetCutsceneVolume(float volume)
    {
        cutsceneVolume = volume;
    }

    public void SetEnemyVolume(float volume)
    {
        enemyVolume = volume;
    }
}
