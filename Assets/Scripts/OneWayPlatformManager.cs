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

        if (!GameObject.Find("player").GetComponent<PlayerControllerScript>().IsStuck() && !GameObject.Find("player").GetComponent<PlayerControllerScript>().IsGrounded2())
        {
            isStuck = true;
        }
        else
        {
            isStuck = false;
        }

        if (isColliding && isStuck && GameObject.Find("player").GetComponent<PlayerControllerScript>().rb.velocity.y == 0)
        {
            Debug.Log(isStuck.ToString());
            Debug.Log("unstuck the player");
            platformEffector.rotationalOffset = 180;
        }

        //Debug.Log(GameObject.Find("player").GetComponent<PlayerControllerScript>().rb.velocity.y.ToString());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        platformEffector.rotationalOffset = 0;
        if (isStuck)
        {
            isStuck = false;
        }
        isColliding = true;
        Debug.Log("is Colliding");
        Debug.Log(isStuck.ToString());
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            platformEffector.rotationalOffset = 180;
        }

        //if mcfucking not stuck then dont mcfucking unstuck

        //if (GameObject.Find("player").GetComponent<PlayerControllerScript>().IsGrounded2() && GameObject.Find("player").GetComponent<PlayerControllerScript>().IsStuck())
        //{
        //    isStuck = false;
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        platformEffector.rotationalOffset = 0;
        isColliding = false;
        Debug.Log("is not Colliding");
        Debug.Log(isStuck.ToString());
    }
}
