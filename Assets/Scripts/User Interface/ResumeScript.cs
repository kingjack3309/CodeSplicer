using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeScript : MonoBehaviour
{
    [SerializeField] GameObject settingsUI;

    InventoryToggle inventoryToggle;

    // Start is called before the first frame update
    void Start()
    {
        inventoryToggle = GameObject.Find("Inventory Manager").GetComponent<InventoryToggle>();
        settingsUI.SetActive(false);
    }

    public void Resume()
    {
        inventoryToggle.UnPause();
    }

    public void Settings()
    {
        settingsUI.SetActive(true);
        inventoryToggle.pauseMenu.SetActive(false);

    }
}
