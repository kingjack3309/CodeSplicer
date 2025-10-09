using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneWayPlatformManager : MonoBehaviour
{

    PlatformEffector2D platformEffector;

    bool isColliding;

    bool isStuck;

    // Start is called before the first frame update
    void Start()
    {
        platformEffector = GetComponentInChildren<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            platformEffector.rotationalOffset = 0;
        }

        if (!GameObject.Find("player").GetComponent<PlayerControllerScript>().IsStuck())
        {
            isStuck = true;
        }
        else
        {
            isStuck= false;
        }

        if (isColliding && isStuck && GameObject.Find("player").GetComponent<PlayerControllerScript>().rb.velocity.y == 0)
        {
            Debug.Log("unstuck the player");
            platformEffector.rotationalOffset = 180;
        }

        //Debug.Log(GameObject.Find("player").GetComponent<PlayerControllerScript>().rb.velocity.y.ToString());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        platformEffector.rotationalOffset = 0;
        isColliding = true;
        Debug.Log("is Colliding");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            platformEffector.rotationalOffset = 180;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        platformEffector.rotationalOffset = 0;
        isColliding = false;
        Debug.Log("is not Colliding");
    }
}
