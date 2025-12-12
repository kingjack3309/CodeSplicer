using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCameraSwaper : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject settingsUI;

    private void Start()
    {
        DontDestroyOnLoadManager.DontDestroyOnLoad(this.gameObject);
    }

    public void SetCamera()
    {
        inventory.GetComponent<Canvas>().worldCamera = Camera.main;
        pauseMenu.GetComponent<Canvas>().worldCamera = Camera.main;
        settingsUI.GetComponent<Canvas>().worldCamera = Camera.main;
    }
}
