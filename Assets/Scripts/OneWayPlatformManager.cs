using UnityEngine;

public class OneWayPlatformManager : MonoBehaviour
{

    private Collider2D platformCollider;
    private Collider2D playerCollider;
    private bool isFallingThrough = false;

    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }

    void Update()
    {
        // Reference height is the Marker's Y position
        float platformTop = platformCollider.bounds.max.y;
        float playerFeet = playerCollider.bounds.min.y;

        // Toggle 'S' to start falling through
        if (Input.GetKeyDown(KeyCode.S) && playerFeet > platformTop - 0.1f)
        {
            isFallingThrough = true;
        }

        // AUTO-OFF: If player feet are below platform height
        // OR if the player has toggled the 'fall through' state
        if (playerFeet < platformTop - 0.05f || isFallingThrough)
        {
            Debug.Log("");
            Physics2D.IgnoreCollision(playerCollider, platformCollider, true);
        }
        else
        {
            // Only re-enable if we are clearly above and NOT trying to fall through
            Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        }

        // Reset the toggle once the player has fully cleared the bottom of the platform
        if (isFallingThrough && playerCollider.bounds.max.y < platformTop - 0.5f)
        {
            isFallingThrough = false;
        }
    }

}
