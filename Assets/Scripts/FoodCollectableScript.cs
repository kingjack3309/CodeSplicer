using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectableScript : MonoBehaviour
{
    private float startY;
    private float hoverDistance = 0.2f;
    private float hoverSpeed = 0.30f;
    private float upperBound;
    private float lowerBound;

    [SerializeField] int healAmount = 100;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startY = gameObject.transform.position.y;
        upperBound = startY + hoverDistance;
        lowerBound = startY - hoverDistance;

        rb.velocity = new Vector2(0, Random.Range(0.1f, 0.30f));
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > upperBound)
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
            collider.GetComponent<PlayerControllerScript>().AddHealth(healAmount);
            collider.GetComponent<PlayerControllerScript>().PlayFoodSound();
            gameObject.SetActive(false);
        }

    }
}
