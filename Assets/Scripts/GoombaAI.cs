using UnityEngine;

public class GoombaAI : MonoBehaviour
{

    Vector2 rayOrigin;
    Vector2 rayForwardDirection;
    Vector2 rayDownDirection = Vector2.down;

    float rayLength = 4;

    string enemyFacing = "right";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyFacing == "right")
        {
            rayForwardDirection = Vector2.right;
        }
        else
        {
            rayForwardDirection = Vector2.left;
        }

        RaycastHit2D floorDetector = Physics2D.Raycast(rayOrigin, rayDownDirection, rayLength, LayerMask.GetMask("ground"));
        RaycastHit2D wallDetector = Physics2D.Raycast(rayOrigin, rayForwardDirection, rayLength, LayerMask.GetMask("ground"));

        if (floorDetector.collider == null && enemyFacing == "right")
        {
            enemyFacing = "left";
            Debug.Log("Facing left");
        }
        else if (floorDetector.collider == null && enemyFacing == "left")
        {
            enemyFacing = "right";
            Debug.Log("Facing right");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(rayOrigin, rayForwardDirection);
        Gizmos.DrawRay(rayOrigin, rayDownDirection);
    }
}
