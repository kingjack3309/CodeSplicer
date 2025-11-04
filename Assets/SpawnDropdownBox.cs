using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDropdownBox : MonoBehaviour
{
    public GameObject dropdownPrefab;

    public Transform codeTerminal;

    List<GameObject> dropdownsList = new List<GameObject>();

    public List<GameObject> functionsList = new List<GameObject>();

    public void SpawnDropdown()
    {
        GameObject DropdownBox = Instantiate(dropdownPrefab, codeTerminal);
        dropdownsList.Add(DropdownBox);
    }

    public void RemoveDropdown()
    {
        if (dropdownsList.Count > 0)
        {
            Destroy(dropdownsList[^1]);
            dropdownsList.Remove(dropdownsList[^1]);
        }
    }

    public void RemoveFunction()
    {
        if (functionsList.Count > 0)
        {
            Destroy(functionsList[^1]);
            functionsList.Remove(functionsList[^1]);
        }
    }
}
