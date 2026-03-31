using UnityEngine;

public class GoombaAI : MonoBehaviour
{

    Vector2 rayOrigin;
    Vector2 rayForwardDirection;
    Vector2 rayDownDirection = Vector2.down;

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

        RaycastHit2D floorDetector = Physics2D.Raycast(rayOrigin, rayDownDirection);

        if (floorDetector.collider == null && enemyFacing == "right")
        {
            enemyFacing = "left";
        }
        else if (floorDetector.collider == null && enemyFacing == "left")
        {
            enemyFacing = "right";
        }
    }
}
