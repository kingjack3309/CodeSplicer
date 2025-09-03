using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemHoverScript : MonoBehaviour
{
    private float startY;
    private float hoverDistance = 0.25f;
    private float hoverSpeed = 0.30f;
    private float upperBound;
    private float lowerBound;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startY = gameObject.transform.position.y;
        upperBound = startY + hoverDistance;
        lowerBound = startY - hoverDistance;

        rb.velocity = new Vector2(0, hoverSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > upperBound ) 
        {
            rb.velocity = new Vector2(0, -hoverSpeed);
        }

        if (gameObject.transform.position.y < lowerBound)
        {
            rb.velocity = new Vector2(0, hoverSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
        
    }
}
