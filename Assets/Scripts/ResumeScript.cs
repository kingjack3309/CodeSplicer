using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeScript : MonoBehaviour
{

    InventoryToggle inventoryToggle;

    // Start is called before the first frame update
    void Start()
    {
        inventoryToggle = GameObject.Find("Inventory Manager").GetComponent<InventoryToggle>();
    }

    public void Resume()
    {
        inventoryToggle.UnPause();
    }
}
