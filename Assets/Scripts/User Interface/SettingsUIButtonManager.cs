using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUIButtonManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject audioMenu;

    [SerializeField] GameObject videoMenu;

    [HideInInspector]
    public List<ParticleSystem> uiParticles = new List<ParticleSystem>();
    [HideInInspector]
    public List<ParticleSystem> dynamicParticles = new List<ParticleSystem>();

    private GameObject openMenu;

    [SerializeField] SettingsDataManager settingsDataManager;

    private void Start()
    {
        SubscribeParticleAction();
    }

    public void ExitSettingsMenu()
    {
        pauseMenu.SetActive(true);
        UpdateUIParticles();
        GameObject.Find("SettingsUI").SetActive(false);
    }

    public void ToggleAudioMenu()
    {
        if (openMenu != null)
        {
            openMenu.SetActive(false); //Closes the open menu if there is any
        }

        if (openMenu != audioMenu)
        {
            openMenu = audioMenu; // open new menu
            audioMenu.SetActive(true);
        }
        else if (openMenu == audioMenu) 
        {
            openMenu = null;
        }
        
    }

    public void ToggleVideoMenu()
    {
        if (openMenu != null)
        {
            openMenu.SetActive(false); //Closes the open menu if there is any
        }

        if (openMenu != videoMenu)
        {
            openMenu = videoMenu; // open new menu
            videoMenu.SetActive(true);
        }
        else if (openMenu == videoMenu)
        {
            openMenu = null;
        }
    }

    public void ToggleUIParticles()
    {
        if (uiParticles != null)
        {
            if (settingsDataManager.uiParticlesPlaying)
            {
                settingsDataManager.uiParticlesPlaying = false;
                UpdateUIParticles();
            }

            else
            {
                settingsDataManager.uiParticlesPlaying = true;
                UpdateUIParticles();
            }
        }
    }

    public void ToggleDynamicParticles()
    {
        if (dynamicParticles != null)
        {
            if (settingsDataManager.dynamicParticlesPlaying)
            {
                settingsDataManager.dynamicParticlesPlaying = false;
                UpdateDynamicParticles();
            }

            else
            {
                settingsDataManager.dynamicParticlesPlaying = true;
                UpdateDynamicParticles();
            }
        }
    }

    public void ClearDynamicParticles()
    {
        dynamicParticles.Clear();
    }

    private void SubscribeParticleAction()
    {
        ClearDynamicParticleList += ClearDynamicParticles;
    }

    public static Action UpdateUIParticles;
    public static Action UpdateDynamicParticles;

    public static Action ClearDynamicParticleList;

    public static Action RemoveSubscriberFunctions;
}
