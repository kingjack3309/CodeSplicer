using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    SettingsUIButtonManager particleToggle;

    private void Start()
    {
        var AllButtonManagers = FindObjectsByType<SettingsUIButtonManager>(FindObjectsInactive.Include, FindObjectsSortMode.None).Where(t => t.CompareTag("Settings UI"));
        
        particleToggle = AllButtonManagers.FirstOrDefault();

        
    }

}
