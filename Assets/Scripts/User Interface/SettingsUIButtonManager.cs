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

    public void ExitSettingsMenu()
    {
        pauseMenu.SetActive(true);
        GameObject.Find("SettingsUI").SetActive(false);
    }

    public void ToggleAudioMenu()
    {
        if (openMenu != audioMenu)
        {
            openMenu = audioMenu; // open new menu
            audioMenu.SetActive(true);
        }
        else if (openMenu == audioMenu) 
        {
            openMenu = null;
        }
        
        if (openMenu != null)
        {
            openMenu.SetActive(false); //Closes the open menu if there is any
        }

    }

    public void ToggleVideoMenu()
    {

        if (openMenu != videoMenu)
        {
            openMenu = videoMenu; // open new menu
            videoMenu.SetActive(true);
        }
        else if (openMenu == videoMenu)
        {
            openMenu = null;
        }
        if (openMenu != null)
        {
            openMenu.SetActive(false); //Closes the open menu if there is any
        }
    }
}
