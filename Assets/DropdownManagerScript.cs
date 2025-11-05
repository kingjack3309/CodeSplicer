using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownManagerScript : MonoBehaviour
{
    public GameObject[] spawnableFunctions;

    Transform codeTerminal;

    TMP_Dropdown functionDropdown;
    private void Start()
    {
        functionDropdown = GetComponent<TMP_Dropdown>();

        functionDropdown.onValueChanged.AddListener( delegate 
        {
            DropdownValueChanged(functionDropdown); 
        });

        codeTerminal = GameObject.Find("Code Content").transform;
    }

    void  DropdownValueChanged(TMP_Dropdown change)
    {
        int selectedIndex = change.value;

        GameObject prefabToSpawn = spawnableFunctions[selectedIndex];

        if (prefabToSpawn != null)
        {
            GameObject function = Instantiate(prefabToSpawn, codeTerminal); 

            GameObject.Find("Spawn Script Holder").GetComponent<SpawnDropdownBox>().RemoveDropdown();

            GameObject.Find("Spawn Script Holder").GetComponent<SpawnDropdownBox>().dropdownsList.Add(function);

            GameObject.Find("Add Function Button").GetComponent<Button>().interactable = true;
        }

    }

}
