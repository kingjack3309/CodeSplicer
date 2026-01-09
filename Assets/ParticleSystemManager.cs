using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UI;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{

    [SerializeField]SettingsDataManager settingsDataManager;

    ParticleSystem thisParticleSystem;

    void Start()
    {
        Debug.Log(gameObject.name);
        thisParticleSystem = GetComponent<ParticleSystem>();

        thisParticleSystem.Play();
    }

    public void DelegateSubscriber()
    {
        SettingsUIButtonManager.UpdateUIParticles += UIParticleUpdater;
        SettingsUIButtonManager.UpdateDynamicParticles += DynamicParticleUpdater;
    }

    public void UIParticleUpdater()
    {
        if (settingsDataManager.uiParticlesPlaying && this.gameObject.CompareTag("UI Particle"))
        {
            thisParticleSystem.Play();
        }
        else if (!settingsDataManager.uiParticlesPlaying && this.gameObject.CompareTag("UI Particle"))
        {
            thisParticleSystem.Stop();
        }
    }

    public void DynamicParticleUpdater()
    {
        if (settingsDataManager.dynamicParticlesPlaying && this.gameObject.CompareTag("Dynamic Particle"))
        {
            thisParticleSystem.Play();
        }
        else if (!settingsDataManager.dynamicParticlesPlaying && this.gameObject.CompareTag("Dynamic Particle"))
        {
            thisParticleSystem.Stop();
        }
    }
}
