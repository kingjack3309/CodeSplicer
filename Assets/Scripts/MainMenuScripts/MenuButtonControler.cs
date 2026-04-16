using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuButtonControler : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void PlayButtonFunction()
    {
        SceneLoader.Instance.LoadScene("CutScene1", "Main Menu");
    }

    public void LanguagesButtonFunction()
    {
        SceneLoader.Instance.LoadScene("LanguagesScene", "Main Menu");
    }

    public void SettingsButtonFunction()
    {
        SceneLoader.Instance.LoadScene("SettingsScreen", "Main Menu");
    }

    public void DifficultyButtonFunction()
    {
        SceneLoader.Instance.LoadScene("DifficultyScreen", "Main Menu");
    }

    public void SkipCutscene()
    {
        SceneLoader.Instance.LoadScene("Tutorial Scene", "CutScene1");
    }

    public void QuitButtonFunction()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else 
        Application.Quit();
#endif
    }
}
