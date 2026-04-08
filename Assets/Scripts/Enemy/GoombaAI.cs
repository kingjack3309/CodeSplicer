using UnityEngine;

public class GoombaAI : MonoBehaviour
{

    Vector2 rayOrigin;
    Vector2 rayForwardDirection;
    Vector2 rayDownDirection = Vector2.down;

    float rayLength1 = 1f;

    float rayLength2 = 0.3f;

    string enemyFacing = "right";

    float moveSpeed = 4;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {

        rayOrigin = (enemyFacing == "right") ? new Vector2(transform.position.x + 0.5f, transform.position.y - 0.5f) : new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f);

        gameObject.transform.localScale = (enemyFacing == "right") ? new Vector2(1.5f, gameObject.transform.localScale.y) : new Vector2(-1.5f, gameObject.transform.localScale.y);

        rayForwardDirection = (enemyFacing == "right") ? Vector2.right : Vector2.left;

        RaycastHit2D floorDetector = Physics2D.Raycast(rayOrigin, rayDownDirection, rayLength1, LayerMask.GetMask("ground"));
        RaycastHit2D floorDetector2 = Physics2D.Raycast(rayOrigin, rayDownDirection, rayLength1, LayerMask.GetMask("OneWayPlatform"));
        RaycastHit2D wallDetector = Physics2D.Raycast(rayOrigin, rayForwardDirection, rayLength2, LayerMask.GetMask("ground"));

        RaycastHit2D playerDetector = Physics2D.Raycast(rayOrigin, rayForwardDirection, rayLength2, LayerMask.GetMask("Player"));

        if (playerDetector.collider != null)
        {
            //attack coroutine
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 4;
        }

        if ((floorDetector.collider == null && floorDetector2.collider == null) || wallDetector.collider != null)
        {
            FlipDirection();
        }
    }

    void FixedUpdate()
    {
        float moveX = (enemyFacing == "right") ? moveSpeed : -moveSpeed;
        rb.linearVelocity = new Vector2(moveX, rb.linearVelocity.y);
    }

    void FlipDirection()
    {
        enemyFacing = (enemyFacing == "right") ? "left" : "right";
    }

    private void OnDrawGizmos()
    {

        if (Application.isPlaying == false)
        {
            rayOrigin = transform.position;
            rayForwardDirection = (enemyFacing == "right") ? Vector2.right : Vector2.left;
        }

        Gizmos.color = Color.green;
        Gizmos.DrawRay(rayOrigin, rayForwardDirection * rayLength2);
        Gizmos.DrawRay(rayOrigin, rayDownDirection * rayLength1);
    }
}
