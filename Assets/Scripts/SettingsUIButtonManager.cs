using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUIButtonManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void ExitSettingsMenu()
    {
        pauseMenu.SetActive(true);
        GameObject.Find("SettingsUI").SetActive(false);
    }
}
