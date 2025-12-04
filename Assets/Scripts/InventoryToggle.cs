using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    GameObject inventory;

    GameObject gui;

    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory Terminal");
        DontDestroyOnLoad(inventory);
        inventory.SetActive(false);

        gui = GameObject.Find("GUI");

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
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
            gui.SetActive(true);
            isActive = false;
            Time.timeScale = 1;
        }
    }
}
