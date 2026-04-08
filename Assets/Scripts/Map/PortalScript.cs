using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    GameObject loadingScreen;

    [SerializeField] string nextScene;
    [SerializeField] bool nextLevelRandomized;

    [Header("If next level is randomized then pick which")]
    [Header("scenes will be randomized")]
    [SerializeField] List<string> sceneList = new List<string>();

    [Header("special portals like boss fights will use a level counter")]
    [Header("and certian scenes wont count to that counter")]
    [SerializeField] bool sceneCounterAffected = true;

    public string lastScene;

    int sceneCounter = 0;

    int marketcounter = 0;

    string currentScene;

    List<GameObject> persistentObjects;

    public void DestroyPersistentObjects()
    {
        foreach (GameObject obj in persistentObjects)
        {
            Destroy(obj);
        }
    }

    private void Awake()
    {
        loadingScreen = GameObject.Find("LoadingScreen");

        persistentObjects = new List<GameObject>() { GameObject.Find("player"), GameObject.Find("Virtual Camera"), GameObject.Find("UI"), GameObject.Find("Inventory Manager")};
        lastScene = SceneManager.GetSceneAt(0).name;

        if (SceneManager.sceneCount == 2)
        {
            currentScene = SceneManager.GetSceneAt(1).name;
        }
    }

    private void Start()
    {
        loadingScreen.SetActive(false);
    }

    private void Update()
    {
        if (SceneManager.sceneCount == 2)
        {
            if (SceneManager.GetSceneAt(1).isLoaded && lastScene != null)
            {
                SceneManager.UnloadSceneAsync(lastScene, UnloadSceneOptions.None);
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            loadingScreen.SetActive(true);

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

                if(nextScene == "Main Menu" || nextScene == "Tutorial Scene")
                {
                    DestroyPersistentObjects();
                }

                SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
            }
            else if (nextLevelRandomized)
            {
                SceneManager.LoadSceneAsync(sceneList[Random.Range(0, sceneList.Count)], LoadSceneMode.Additive);
            }
            
            collider.GetComponent<PlayerControllerScript>().ReturnToStart();
        }
    }
}
