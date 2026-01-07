using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyUi : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoadManager.DontDestroyOnLoad(this.gameObject);
    }
}
