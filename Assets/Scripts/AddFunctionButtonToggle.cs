using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddFunctionButtonToggle : MonoBehaviour
{
    Button addFunctionButton;

    private void Start()
    {
        addFunctionButton = GetComponent<Button>();

        SpawnDropdownBox.enableSpawn += EnableButton;
    }
    public void DisableButton()
    {
        addFunctionButton.interactable = false;
    }

    public void EnableButton()
    {
        addFunctionButton.interactable = true;
    }
}
