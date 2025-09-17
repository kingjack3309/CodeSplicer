using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    GameObject dialogBox;

    private void Awake()
    {
        dialogBox = GameObject.Find("DialogBox");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            loadingScreen.SetActive(true);
            dialogBox.SetActive(true);
            SceneManager.LoadScene("StageOneLevelA");
            collider.GetComponent<PlayerControllerScript>().ReturnToStart();
        }
    }
}
