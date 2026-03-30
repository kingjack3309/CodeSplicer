using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageStringManager : MonoBehaviour
{
    [HideInInspector]
    public string constantLanguage;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateLanguage(LanguageOptions languageOptionsInstance)
    {
        languageOptionsInstance.language = constantLanguage;
        languageOptionsInstance.ChangeLanguage();
    }
}
