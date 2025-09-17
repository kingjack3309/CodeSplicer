using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PopUpTextSignScript : MonoBehaviour
{
    GameObject npcText;
    GameObject scrollbar;

    DialogBoxManagerScript dialogBoxManagerScript;

    public string npcDialog = "";

    private void Start()
    {
        npcText = GameObject.Find("NPCText");
        
        scrollbar = GameObject.Find("Scrollbar Vertical");

        dialogBoxManagerScript = GameObject.Find("DialogBoxManager").GetComponent<DialogBoxManagerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogBoxManagerScript.BoxSleep(true);
            scrollbar.GetComponent<Scrollbar>().value = 1;
            npcText.GetComponent<TMP_Text>().text = npcDialog;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogBoxManagerScript.BoxSleep(false);
            npcText.GetComponent<TMP_Text>().text = "";
        }
    }
}
