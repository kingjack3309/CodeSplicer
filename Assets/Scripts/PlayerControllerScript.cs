using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControllerScript : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 13f;
    private bool isFacingRight = false;
    private bool canDoubleJump = false;
    private bool doubleJumpped = false;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float groundCheckWidth = 1.26f;
    private float groundCheckHeight = 0.1f;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Jump();

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity =new Vector2(speed * horizontal, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(groundCheckWidth, groundCheckHeight), 0, groundLayer);
    }

    private void OnDrawGizmos() 
    {
        // Set the color with custom alpha.
        Gizmos.color = new Color(0f, 1f, 0f, 10); // Green with custom alpha

        // Draw the cube.
        Gizmos.DrawCube(groundCheck.position, new Vector3(groundCheckWidth, groundCheckHeight, 0));

        // Draw a wire cube outline.
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheck.position, new Vector3(groundCheckWidth, groundCheckHeight, 0));
    }

    private void Flip()
    {
        if (isFacingRight && horizontal <0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void Jump()
    {
        if (doubleJumpped && IsGrounded())
        {
            doubleJumpped = false;
        }

        if (!IsGrounded() && !doubleJumpped) 
        { 
            canDoubleJump = true;
        }
        else if (doubleJumpped)
        {
            canDoubleJump = false;
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            doubleJumpped = true;
        }
    }
}
