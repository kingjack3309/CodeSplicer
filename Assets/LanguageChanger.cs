using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChanger : MonoBehaviour
{
    public LanguageData languageData;

    public string languageName;

    public void SetNewLanguage()
    {
        languageData.language = languageName;

        languageData.ChangeLanguage();
    }
}
