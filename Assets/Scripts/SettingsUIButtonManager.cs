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

    public void ExitSettingsMenu()
    {
        pauseMenu.SetActive(true);
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
            foreach (ParticleSystem p in uiParticles)
            {
                if (p.isPlaying)
                {
                    p.Stop();
                }

                else
                {
                    p.Play();
                }
            }
        }
    }

    public void ToggleDynamicParticles()
    {
        if (dynamicParticles != null)
        {
            foreach (ParticleSystem p in dynamicParticles)
            {
                if (p.isPlaying)
                {
                    p.Stop();
                }

                else
                {
                    p.Play();
                }
            }
        }
    }

}
