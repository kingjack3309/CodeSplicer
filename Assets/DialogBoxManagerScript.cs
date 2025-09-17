using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxManagerScript : MonoBehaviour
{
    GameObject dialogBox;
    GameObject npcText;
    GameObject scrollbar;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        dialogBox = GameObject.Find("DialogBox");

        npcText = GameObject.Find("NPCText");

        scrollbar = GameObject.Find("Scrollbar Vertical");

        dialogBox.SetActive(false);
    }

    public void BoxSleep(bool boolChoice)
    {
        dialogBox.SetActive(boolChoice);
    }

    public void ChangeDialog(string npcDialogue)
    {
        scrollbar.GetComponent<Scrollbar>().value = 1;
        npcText.GetComponent<TMP_Text>().text = npcDialogue;
    }

    public void ClearDialog()
    {
        npcText.GetComponent<TMP_Text>().text = "";
    }

}
