using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


}
