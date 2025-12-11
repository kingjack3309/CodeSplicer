using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoadManager.DontDestroyOnLoad(this.gameObject);
    }
}
