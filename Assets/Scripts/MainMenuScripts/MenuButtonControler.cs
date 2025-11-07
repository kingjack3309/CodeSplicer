using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
}
