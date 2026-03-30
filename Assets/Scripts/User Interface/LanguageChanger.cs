using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChanger : MonoBehaviour
{

    public string languageName;

    public void SetNewLanguage()
    {
        GameObject[] textObjects = GameObject.FindGameObjectsWithTag("Text");

        foreach (GameObject textObject in textObjects)
        {
            textObject.GetComponent<LanguageOptions>().language = languageName;
            textObject.GetComponent<LanguageOptions>().ChangeLanguage();
        }

        GameObject.Find("Language Name Holder").GetComponent<LanguageStringManager>().constantLanguage = languageName;
    }
}
