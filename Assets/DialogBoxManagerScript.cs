using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBoxManagerScript : MonoBehaviour
{
    GameObject dialogBox;

    private void Start()
    {
        dialogBox = GameObject.Find("DialogBox");
        dialogBox.SetActive(false);
    }

    public void BoxSleep(bool boolChoice)
    {
        dialogBox.SetActive(boolChoice);
    }
}
