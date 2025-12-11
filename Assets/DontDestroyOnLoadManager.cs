using System.Collections.Generic;
using UnityEngine;

public static class DontDestroyOnLoadManager
{
    static List<GameObject> _ddolObjects = new List<GameObject>();

    // A custom method to use instead of the native Unity one
    public static void DontDestroyOnLoad(GameObject go)
    {
        UnityEngine.Object.DontDestroyOnLoad(go);
        _ddolObjects.Add(go);
    }

    // A method to destroy all tracked objects
    public static void DestroyAll()
    {
        foreach (var go in _ddolObjects)
        {
            if (go != null)
            {
                UnityEngine.Object.Destroy(go);
            }
        }
        _ddolObjects.Clear();
    }
}