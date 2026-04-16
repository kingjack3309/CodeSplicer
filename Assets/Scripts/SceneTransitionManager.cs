using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTransitionManager
{
    // Static variables to hold the information we need to pass between scenes
    public static string sceneToUnload;
    public static string nextActiveScene;
}