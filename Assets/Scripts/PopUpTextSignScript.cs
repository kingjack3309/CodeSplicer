using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTextSignScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI npcText;
    [SerializeField] GameObject dialogBox;
    //[SerializeField] Scrollbar scrollbar;

    public string npcDialog = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogBox.
            dialogBox.SetActive(true);
            npcText.text = npcDialog;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogBox.SetActive(false);
            npcText.text = "";
        }
    }
}
