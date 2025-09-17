using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PopUpTextSignScript : MonoBehaviour
{
    

    DialogBoxManagerScript dialogBoxManagerScript;

    public string npcDialog = "";

    private void Start()
    {  
        dialogBoxManagerScript = GameObject.Find("DialogBoxManager").GetComponent<DialogBoxManagerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogBoxManagerScript.BoxSleep(true);
            dialogBoxManagerScript.ChangeDialog(npcDialog);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogBoxManagerScript.BoxSleep(false);
            dialogBoxManagerScript.ClearDialog();
        }
    }
}
