using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    GameObject inventory;

    GameObject gui;

    [HideInInspector]
    public GameObject pauseMenu;

    GameObject ui;

    public GameObject settingsMenu;

    bool isActive = false;
    bool isActive2 = false;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory Terminal");
        pauseMenu = GameObject.Find("Pause Menu");
        inventory.SetActive(false);
        pauseMenu.SetActive(false);

        gui = GameObject.Find("GUI");

        ui = GameObject.Find("UI");
        DontDestroyOnLoadManager.DontDestroyOnLoad(ui);

        DontDestroyOnLoadManager.DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        ToggleInventory();

        TogglePauseMenu();
    }

    public void ToggleInventory()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isActive)
        {
            inventory.SetActive(true);
            gui.SetActive(false);
            isActive = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && isActive)
        {
            inventory.SetActive(false);
            isActive = false;
            if (!isActive && !isActive2)
            {
                gui.SetActive(true);
                Time.timeScale = 1;
            }
        }
    }

    public void TogglePauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && settingsMenu.activeSelf)
        {
            settingsMenu.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !isActive2)
        {
            pauseMenu.SetActive(true);
            gui.SetActive(false);
            isActive2 = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isActive2)
        {
            pauseMenu.SetActive(false);
            isActive2 = false;
            if (!isActive && !isActive2)
            {
                gui.SetActive(true);
                Time.timeScale = 1;
            }
        }
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        isActive2 = false;
        if (!isActive && !isActive2)
        {
            gui.SetActive(true);
            Time.timeScale = 1;
        }
    }

}
