using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLoadingScreenScript : MonoBehaviour
{

    GameObject loadingScreen;

    DialogBoxManagerScript dialogBoxManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogBoxManager = GameObject.Find("DialogBoxManager").GetComponent<DialogBoxManagerScript>();

        loadingScreen = GameObject.Find("LoadingScreen");

        if (loadingScreen != null && loadingScreen.activeSelf == true)
        {
            loadingScreen.SetActive(false);
        } 

        if (dialogBoxManager != null && dialogBoxManager.GetDialogActive())
        {
            dialogBoxManager.BoxActive(false);
        }
    }
}
