using Unity.VisualScripting;
using UnityEngine;

public class OneWayPlatformManager : MonoBehaviour
{

    private Collider2D platformCollider;
    private PolygonCollider2D playerCollider;
    private bool isFallingThrough = false;

    private float platformTop;
    private float playerFeet;

    private bool standingOnPlatform;

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

        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && playerFeet > platformTop - 0.1f && standingOnPlatform)
        {
            isFallingThrough = true;
        }

        if (playerFeet < platformTop - 0.03f || isFallingThrough)
        {
            Physics2D.IgnoreCollision(playerCollider, platformCollider, true);
        }
        else
        {
            Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        }

        if (isFallingThrough && playerCollider.bounds.max.y < platformTop - 0.3f)
        {
            isFallingThrough = false;
        }
    }

    private void OnCollisionEnter2D()
    {
        standingOnPlatform = true;
    }

    private void OnCollisionExit2D()
    {
        standingOnPlatform = false;
    }

}
