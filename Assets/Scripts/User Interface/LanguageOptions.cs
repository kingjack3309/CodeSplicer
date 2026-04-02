using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageOptions : MonoBehaviour
{
    [Header("Language Translations")]
    public string americanTXT;
    public string brittishTXT;
    public string germanTXT;
    public string russianTXT;

    TMP_Text textLabel;

    [Header("Fonts")]
    public TMP_FontAsset russianFont;
    public TMP_FontAsset pixelFont;

    [HideInInspector]
    public string language = "american";

    LanguageStringManager languageStringManager;

    private void Start()
    {
        if (GameObject.Find("Language Name Holder") != null)
        {
            languageStringManager = GameObject.Find("Language Name Holder").GetComponent<LanguageStringManager>();
            textLabel = GetComponent<TMP_Text>();
            LanguageUpdate += languageStringManager.UpdateLanguage;
            LanguageUpdate.Invoke(this);
        }
    }

    public void ChangeLanguage()
    {
        if (language == "american")
        {
            textLabel.text = americanTXT;
            textLabel.font = pixelFont;
        }

        if (language == "brittish")
        {
            textLabel.text = brittishTXT;
            textLabel.font = pixelFont;
        }

        if (language == "german")
        {
            textLabel.text = germanTXT;
            textLabel.font = pixelFont;
        }

        if (language == "russian")
        {
            textLabel.font = russianFont;
            textLabel.text = russianTXT;
        }
    }

    public delegate void TextHandler(LanguageOptions instance);
    public event TextHandler LanguageUpdate;
}
