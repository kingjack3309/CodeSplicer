using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLoadingScreenScript : MonoBehaviour
{

    GameObject loadingScreen;

    // Start is called before the first frame update
    void Start()
    {
        loadingScreen = GameObject.Find("LoadingScreen");

        if (loadingScreen != null && loadingScreen.activeSelf == true)
        {
            loadingScreen.SetActive(false);
        } 
    }
}
