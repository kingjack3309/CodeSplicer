using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageUpdate : MonoBehaviour
{
    
    public LanguageData languageData;

    void Start()
    {
        languageData.ChangeLanguage();
    }

    
}
