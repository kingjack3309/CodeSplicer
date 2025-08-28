using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonControler : MonoBehaviour
{
   public void PlayButtonFunction()
    {
        SceneManager.LoadScene("Tutorial Scene");
    }
}
