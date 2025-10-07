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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            platformEffector.rotationalOffset = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        platformEffector.rotationalOffset = 0;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            platformEffector.rotationalOffset = 180;
        }

        if (!GameObject.Find("player").GetComponent<PlayerControllerScript>().IsStuck() && GameObject.Find("player").GetComponent<PlayerControllerScript>().rb.velocity.y == 0)
        {
            platformEffector.rotationalOffset = 180;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        platformEffector.rotationalOffset = 0;
    }
}
