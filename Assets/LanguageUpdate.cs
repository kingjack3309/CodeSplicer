using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageUpdate : MonoBehaviour
{
    
    [SerializeField] LanguageData languageData;

    private void Start() 
    {
        languageData.ChangeLanguage();
    }
}
