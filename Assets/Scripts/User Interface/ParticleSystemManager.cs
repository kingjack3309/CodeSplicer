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
        thisParticleSystem = GetComponent<ParticleSystem>();
        //Debug.Log($"{gameObject.name} {thisParticleSystem != null}");

        //thisParticleSystem.Play();

        SettingsUIButtonManager.RemoveSubscriberFunctions += RemoveSubscribers;
    }

    public void DelegateSubscriber()
    {
        if (gameObject.tag == "UI Particle")
        {
            SettingsUIButtonManager.UpdateUIParticles += UIParticleUpdater;
        }
        else if (gameObject.tag == "Dynamic Particle")
        {
            SettingsUIButtonManager.UpdateDynamicParticles += DynamicParticleUpdater;
        }
    }

    public void RemoveSubscribers()
    {
        if (gameObject.tag == "UI Particle")
        {
            SettingsUIButtonManager.UpdateUIParticles -= UIParticleUpdater;
        }
        else if (gameObject.tag == "Dynamic Particle")
        {
            SettingsUIButtonManager.UpdateDynamicParticles -= DynamicParticleUpdater;
        }
    }

    public void UIParticleUpdater()
    {
        if (settingsDataManager.uiParticlesPlaying && this.gameObject.CompareTag("UI Particle"))
        {
            //Debug.Log($"{gameObject.name} {thisParticleSystem != null}");

            if (thisParticleSystem == null)
            {
                thisParticleSystem = GetComponent<ParticleSystem>();
            }
            
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
