using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            loadingScreen.SetActive(true);
            SceneManager.LoadScene("StageOneLevelA");
            collider.GetComponent<PlayerControllerScript>().ReturnToStart();
        }
    }
}
