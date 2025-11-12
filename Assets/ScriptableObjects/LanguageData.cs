using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLanguageData", menuName = "language data")]
public class LanguageData : ScriptableObject
{

    public string language;

    public void ChangeLanguage() 
    {
        GameObject[] textObject = GameObject.FindGameObjectsWithTag("Text");

        if (language == "american")
        {
            foreach (GameObject game_Object in textObject)
            {
                game_Object.GetComponent<TMP_Text>().text = game_Object.GetComponent<LanguageOptions>().americanTXT;
            }
        }

        if (language == "brittish")
        {
            foreach (var game_Object in textObject)
            {
                game_Object.GetComponent<TMP_Text>().text = game_Object.GetComponent<LanguageOptions>().brittishTXT;
            }
        }

        if (language == "german")
        {
            foreach (var game_Object in textObject)
            {
                game_Object.GetComponent<TMP_Text>().text = game_Object.GetComponent<LanguageOptions>().germanTXT;
            }
        }

        if (language == "russian")
        {
            foreach (var game_Object in textObject)
            {
                game_Object.GetComponent<TMP_Text>().text = game_Object.GetComponent<LanguageOptions>().russianTXT;
            }
        }
    }
}
