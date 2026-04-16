using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    [SerializeField] string nextScene;
    [SerializeField] bool nextLevelRandomized;

    [Header("If next level is randomized then pick which")]
    [Header("scenes will be randomized")]
    [SerializeField] List<string> sceneList = new List<string>();

    [Header("special portals like boss fights will use a level counter")]
    [Header("and certian scenes wont count to that counter")]
    [SerializeField] bool sceneCounterAffected = true;

    private static int sceneCounter = 0;
    private static int marketcounter = 0;

    private List<GameObject> persistentObjects;

    public void DestroyPersistentObjects()
    {
        foreach (GameObject obj in persistentObjects)
        {
            Destroy(obj);
        }
    }

    private void Awake()
    {
        persistentObjects = new List<GameObject>() {
            GameObject.Find("player"),
            GameObject.Find("Virtual Camera"),
            GameObject.Find("UI"),
            GameObject.Find("Inventory Manager")
        };
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Get the scene this portal is actually in (guaranteed correct)
            string sceneToUnload = gameObject.scene.name;

            Debug.Log($"Portal triggered in: {sceneToUnload} | Active scene: {SceneManager.GetActiveScene().name}");

            // Game logic for scene selection
            if (sceneCounterAffected)
            {
                sceneCounter++;
            }

            if (marketcounter < 2 && sceneCounter == 4)
            {
                if (marketcounter == 0 || marketcounter == 1)
                {
                    nextScene = "MarketScene";
                    nextLevelRandomized = false;
                }
                marketcounter++;
                sceneCounter = 0;
            }
            else if (marketcounter == 2 && sceneCounter == 4)
            {
                marketcounter = 0;
                sceneCounter = 0;
            }

            string sceneToLoadName = "";
            if (!nextLevelRandomized)
            {
                if (sceneToUnload == "MarketScene")
                {
                    nextLevelRandomized = true;
                }

                if (nextScene == "Main Menu" || nextScene == "Tutorial Scene")
                {
                    DestroyPersistentObjects();
                }
                sceneToLoadName = nextScene;
            }
            else if (nextLevelRandomized)
            {
                sceneToLoadName = sceneList[Random.Range(0, sceneList.Count)];
            }

            // Load new scene and unload THIS portal's scene
            SceneLoader.Instance.LoadScene(sceneToLoadName, sceneToUnload);

            collider.GetComponent<PlayerControllerScript>().ReturnToStart();
        }
    }
}