using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    private GameObject loadingScreen = null;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        if (loadingScreen == null)
        {
            loadingScreen = GameObject.FindObjectsByType<LoadingScreenScript>(FindObjectsInactive.Include, FindObjectsSortMode.None)[0].gameObject;
        }
    }

    public void LoadScene(string sceneToLoad, string sceneToUnload)
    {
        StartCoroutine(LoadSceneCoroutine(sceneToLoad, sceneToUnload));
    }

    private IEnumerator LoadSceneCoroutine(string sceneToLoadName, string sceneToUnloadName)
    {
        // Load new scene additively
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(sceneToLoadName, LoadSceneMode.Additive);

        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true);
        }

        yield return new WaitUntil(() => loadOp.isDone);

        // Wait for scene to be fully registered
        yield return null;

        Scene newScene = SceneManager.GetSceneByName(sceneToLoadName);

        if (!newScene.IsValid())
        {
            Debug.LogError($"SceneLoader: Failed to find loaded scene '{sceneToLoadName}'");
            yield break;
        }

        // UNLOAD OLD SCENE FIRST
        if (!string.IsNullOrEmpty(sceneToUnloadName))
        {
            Scene oldScene = SceneManager.GetSceneByName(sceneToUnloadName);

            if (oldScene.IsValid() && oldScene.isLoaded)
            {
                AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(oldScene);
                yield return new WaitUntil(() => unloadOp.isDone);
                Debug.Log($"SceneLoader: Unloaded '{sceneToUnloadName}'");
            }
            else
            {
                Debug.LogWarning($"SceneLoader: Could not find scene to unload '{sceneToUnloadName}'");
            }
        }

        // NOW set new scene as active
        SceneManager.SetActiveScene(newScene);

        yield return new WaitForSeconds(0.5f);

        if (loadingScreen != null)
        {
            loadingScreen.SetActive(false);
        }
    }
}