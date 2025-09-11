using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CenematicWalkingScript : MonoBehaviour
{

    Rigidbody2D rb;

    private float startY = -10;
    private float endY = -1;
    private float walkSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(0, startY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < endY)
        {
            rb.velocity = new Vector2(0, walkSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
