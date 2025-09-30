using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneWayPlatformManager : MonoBehaviour
{

    PlatformEffector2D platformEffector;

    // Start is called before the first frame update
    void Start()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(DropDownCoroutine());
        }
    }

    IEnumerator DropDownCoroutine()
    {
        platformEffector.rotationalOffset = 180;
        yield return new WaitForSeconds(0.5f);
        platformEffector.rotationalOffset = 0;
    }

}
