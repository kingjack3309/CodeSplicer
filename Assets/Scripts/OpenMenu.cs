using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{

    public GameObject destroyed;
    public GameObject destroyed2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadSceneAsync("Main Menu", LoadSceneMode.Additive);
        StartCoroutine(LoadingScreen());
    }

    private IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
        Destroy(destroyed);
        Destroy(destroyed2);
    }
}
