using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    SettingsUIButtonManager particleToggle;

    private void Start()
    {
        var AllButtonManagers = FindObjectsByType<SettingsUIButtonManager>(FindObjectsInactive.Include, FindObjectsSortMode.None).Where(t => t.CompareTag("Settings UI"));
        
        particleToggle = AllButtonManagers.FirstOrDefault();

        FindDynamicParticleSystems();
        FindUIParticleSystems();
    }

    public void FindUIParticleSystems()
    {
        var uiParticleSystems = FindObjectsByType<ParticleSystem>(FindObjectsInactive.Include, FindObjectsSortMode.None).Where(t => t.CompareTag("UI Particle"));
        foreach (var system in uiParticleSystems)
        {
            particleToggle.uiParticles.Add(system);
            system.GetComponentInParent<ParticleSystemManager>().DelegateSubscriber();
        }
    }

    public void FindDynamicParticleSystems()
    {
        var dynamicParticleSystems = FindObjectsByType<ParticleSystem>(FindObjectsInactive.Include, FindObjectsSortMode.None).Where(t => t.CompareTag("Dynamic Particle"));
        foreach (var system in dynamicParticleSystems)
        {
            particleToggle.dynamicParticles.Add(system);
            system.GetComponentInParent<ParticleSystemManager>().DelegateSubscriber();
        }
    }

}
