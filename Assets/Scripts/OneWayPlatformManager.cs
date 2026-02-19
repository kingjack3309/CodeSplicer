using Unity.VisualScripting;
using UnityEngine;

public class OneWayPlatformManager : MonoBehaviour
{

    private Collider2D platformCollider;
    private PolygonCollider2D playerCollider;
    private bool isFallingThrough = false;

    private float platformTop;
    private float playerFeet;

    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        if (playerCollider == null)
        {
            Debug.Log("no player collider");
        }

        // Reference height is the Marker's Y position
        float platformTop = platformCollider.bounds.max.y;
        float playerFeet = playerCollider.bounds.min.y;
        
        if (playerFeet < platformTop - 0.05f || isFallingThrough)
        {
            Physics2D.IgnoreCollision(playerCollider, platformCollider, true);
        }
        else
        {
            Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        }

        if (isFallingThrough && playerCollider.bounds.max.y < platformTop - 0.5f)
        {
            isFallingThrough = false;
        }
    }

    private void OnCollisionEnter2D()
    {
        if (Input.GetKeyDown(KeyCode.S) && playerFeet > platformTop - 0.1f)
        {
            isFallingThrough = true;
        }
    }

}
