using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]SettingsUIButtonManager uiParticleToggle;

    [SerializeField] SettingsUIButtonManager dynamicParticleToggle;

    private void Start()
    {
        FindDynamicParticleSystems();
        FindUIParticleSystems();
    }

    public void FindUIParticleSystems()
    {
        var uiParticleSystems = FindObjectsByType<ParticleSystem>(FindObjectsInactive.Include, FindObjectsSortMode.None).Where(t => t.CompareTag("UI Particle"));
        foreach (var system in uiParticleSystems)
        {
            uiParticleToggle.uiParticles.Add(system);
            system.GetComponentInParent<ParticleSystemManager>().DelegateSubscriber();
        }
    }

    public void FindDynamicParticleSystems()
    {
        var dynamicParticleSystems = FindObjectsByType<ParticleSystem>(FindObjectsInactive.Include, FindObjectsSortMode.None).Where(t => t.CompareTag("Dynamic Particle"));
        foreach (var system in dynamicParticleSystems)
        {
            dynamicParticleToggle.dynamicParticles.Add(system);
            system.GetComponentInParent<ParticleSystemManager>().DelegateSubscriber();
        }
    }

}
