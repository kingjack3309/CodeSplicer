using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuButtonControler : MonoBehaviour
{
   public void PlayButtonFunction()
    {
        SceneManager.LoadScene("CutScene1");
    }

    public void LanguagesButtonFunction()
    {
        SceneManager.LoadScene("Languages Screen");
    }

    public void SettingsButtonFunction()
    {
        SceneManager.LoadScene("SettingsScreen");
    }

    public void SkipCutscene()
    {
        SceneManager.LoadScene("Tutorial Scene");
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
