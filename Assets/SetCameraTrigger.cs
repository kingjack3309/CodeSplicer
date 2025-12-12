using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("CameraSetter").GetComponent<RenderCameraSwaper>().SetCamera();
    }
}
