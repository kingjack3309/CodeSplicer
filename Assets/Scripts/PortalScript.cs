using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    GameObject loadingScreen;
    DialogBoxManagerScript dialogBoxManagerScript;

    [SerializeField] string nextScene;
    [SerializeField] bool nextLevelRandomized;

    [Header("If level is randomized then pick which")]
    [Header("scenes will be randomized")]
    [SerializeField] List<string> sceneList = new List<string>();

    [Header("special portals like boss fights will use a level counter")]
    [Header(" and certian scenes wont count to that counter")]
    [SerializeField] bool sceneCounterAffected = true;

    int sceneCounter = 0;

    int marketcounter = 0;

    string currentScene;

    private void Awake()
    {
        dialogBoxManagerScript = GameObject.Find("DialogBoxManager").GetComponent<DialogBoxManagerScript>();
        currentScene = SceneManager.GetActiveScene().name;
        loadingScreen = GameObject.Find("LoadingScreen");
    }

    private void Start()
    {
        loadingScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            loadingScreen.SetActive(true);
            dialogBoxManagerScript.BoxActive(true);

            if (sceneCounterAffected) 
            { 
                sceneCounter++; 
            }

            if (marketcounter < 2 && sceneCounter == 4) //if you have not had 2 markets yet it will create a market
            {
                if (marketcounter == 0 || marketcounter == 1)
                {
                    nextScene = "MarketScene";
                    nextLevelRandomized = false;
                }
                marketcounter++; 
                sceneCounter = 0;
            }

            else if (marketcounter == 2 && sceneCounter == 4) //if you have had 2 markets then 4 levels later you get a bossfight
            {
                marketcounter = 0;
                sceneCounter = 0;
            }

            if (!nextLevelRandomized) 
            {
                if (currentScene == "MarketScene")
                {
                    nextLevelRandomized = true;
                }
                SceneManager.LoadScene(nextScene);
            }
            else if (nextLevelRandomized)
            {
                SceneManager.LoadScene(sceneList[Random.Range(0, sceneList.Count)]);
            }
            
            collider.GetComponent<PlayerControllerScript>().ReturnToStart();
        }
    }
}
