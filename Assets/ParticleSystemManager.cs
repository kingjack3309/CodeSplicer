using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UI;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{

    SettingsDataManager settingsDataManager;

    ParticleSystem thisParticleSystem;

    void Start()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();

        if (settingsDataManager.uiParticlesPlaying && this.gameObject.CompareTag("UI Particle"))
        {
            thisParticleSystem.Play();
        }
        else
        {
            thisParticleSystem.Stop();
        }

        if (settingsDataManager.dynamicParticlesPlaying && this.gameObject.CompareTag("Dynamic Particle"))
        {
            thisParticleSystem.Play();
        }
        else
        {
            thisParticleSystem.Stop();
        }
    }

    public void DelegateSubscriber()
    {
        SettingsUIButtonManager.UpdateParticles += UIParticleUpdater;
        SettingsUIButtonManager.UpdateParticles += DynamicParticleUpdater;
    }

    public void UIParticleUpdater()
    {
        if (settingsDataManager.uiParticlesPlaying && this.gameObject.CompareTag("UI Particle"))
        {
            thisParticleSystem.Play();
        }
        else
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
        else
        {
            thisParticleSystem.Stop();
        }
    }
}
