using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneWayPlatformManager : MonoBehaviour
{

    PlatformEffector2D platformEffector;

    private bool noPhasing;
    bool running;

    // Start is called before the first frame update
    void Start()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            platformEffector.rotationalOffset = 0;
        }

        if (GameObject.Find("player").GetComponent<PlayerControllerScript>().IsGrounded2())
        { 
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine(DropDownCoroutine(0.5f));
            }

            else if (noPhasing == true && GameObject.Find("player").GetComponent<Rigidbody2D>().velocity.y < 0 && platformEffector.rotationalOffset == 180 && GameObject.Find("player").GetComponent<PlayerControllerScript>().IsStuck() == false)
            {
                platformEffector.rotationalOffset = 0;
            }
        }

        if (GameObject.Find("player").GetComponent<PlayerControllerScript>().IsStuck() && GameObject.Find("player").GetComponent<Rigidbody2D>().velocity.y <= 0 && !running)
        {
            StartCoroutine(DropDownCoroutine(0.5f));
        }

        if (GameObject.Find("player").GetComponent<PlayerControllerScript>().IsStuck2() && GameObject.Find("player").GetComponent<Rigidbody2D>().velocity.y <= 0 && !running)
        {
            StartCoroutine(DropDownCoroutine(0.3f));
        }
    }

    IEnumerator DropDownCoroutine(float seconds)
    {
        running = true;
        noPhasing = false;
        platformEffector.rotationalOffset = 180;
        yield return new WaitForSeconds(seconds);
        noPhasing = true;
        platformEffector.rotationalOffset = 0;
        running = false;
    }

}
