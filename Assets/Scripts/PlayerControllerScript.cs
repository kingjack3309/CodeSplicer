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
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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
