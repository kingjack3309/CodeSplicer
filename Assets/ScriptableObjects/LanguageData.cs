using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLanguageData", menuName = "language data")]
public class LanguageData : ScriptableObject
{

    public string language = "american";

    public void ChangeLanguage() 
    {
        var textObject = GameObject.FindGameObjectsWithTag("Text");

        if (language == "american")
        {
            foreach (var obj in textObject)
            {
                obj.GetComponent<TMP_Text>().text = obj.GetComponent<LanguageOptions>().americanTXT;
            }
        }

        else if (language == "brittish")
        {
            foreach (var obj in textObject)
            {
                obj.GetComponent<TMP_Text>().text = obj.GetComponent<LanguageOptions>().brittishTXT;
            }
        }

        else if (language == "german")
        {
            foreach (var obj in textObject)
            {
                obj.GetComponent<TMP_Text>().text = obj.GetComponent<LanguageOptions>().germanTXT;
            }
        }

        else if (language == "russian")
        {
            foreach (var obj in textObject)
            {
                obj.GetComponent<TMP_Text>().text = obj.GetComponent<LanguageOptions>().russianTXT;
            }
        }   
    }
}
