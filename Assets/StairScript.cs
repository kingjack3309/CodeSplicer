using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StairScript : MonoBehaviour
{

    PlatformEffector2D platformEffector;

    bool isColliding;

    bool isStuck;

    public bool isRight = true;

    float startAngle = 45;

    // Start is called before the first frame update
    void Start()
    {
        platformEffector = GetComponentInChildren<PlatformEffector2D>();

        if (isRight)
        {
            startAngle = 45;
        }
        else
        {
            startAngle = -45;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            platformEffector.rotationalOffset = startAngle * -1;
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
            platformEffector.rotationalOffset = startAngle;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        platformEffector.rotationalOffset = startAngle * -1;
        if (isStuck)
        {
            isStuck = false;
        }
        isColliding = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            platformEffector.rotationalOffset = startAngle;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        platformEffector.rotationalOffset = startAngle * -1;
        isColliding = false;
    }
}
