using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public float groundCheckWidth = 1.26f;
    private float groundCheckHeight = 0.2f;

    [Header("------Audio Clips------")]
    public AudioClip coinCollected;
    public AudioClip foodCollected;

    AudioSource audioSource;

    HealthManagerScript healthManager;

    GemManager gemManager;

    CodePickupData onLeftClick;
    CodePickupData onRightClick;

    //[Header("------public Variables------")]

    //public float dashStrength = 20f;
    //float dashPower;

    private void Start()
    {
        healthManager = GameObject.Find("healthbar").GetComponent<HealthManagerScript>();
        audioSource = gameObject.GetComponent<AudioSource>();
        gemManager = GameObject.Find("GemsText").GetComponent<GemManager>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Jump();

        //Dash();

        Flip();

        //_____________________
        //Code Snippet section
        if (Input.GetMouseButtonDown(0) && onLeftClick != null)
        {
            onLeftClick.Execute();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);
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
        //if you not grounded coyote timer starts

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        //checking if you can double jump

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

        //the actual jump

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && (IsGrounded() || coyoteTimeCounter > 0f))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            coyoteTimeCounter = 0f;
        }
        
        //The double jump

        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            doubleJumpped = true;
        }
    }

    public void AddHealth(int amount)
    {
        healthManager.GainHealth(amount);
    }

    public void RemoveHealth(int amount)
    {
        healthManager.LoseHealth(amount);
    }


    public void PlayGemSound()
    {
        audioSource.clip = coinCollected;
        audioSource.Play();
    }
  
    public void PlayFoodSound()
    {
        audioSource.clip = foodCollected;
        audioSource.Play();
    }

    public void ReturnToStart()
    {
        gameObject.transform.position = new Vector2(0, 0);
    }

    public void AddGems(int gems)
    {
        gemManager.GainGems(gems);
    }

    public void Knockback(float knockbackStrengthX, float knockbackStrengthY)
    {

        if (knockbackStrengthX == 0f)
        {
            knockbackStrengthX = rb.velocity.x;
        }

        if (knockbackStrengthY == 0f)
        {
            knockbackStrengthY = rb.velocity.y;
        }

        rb.velocity = new Vector2(knockbackStrengthX, knockbackStrengthY);
    }

    //void Dash()
    //{
    //    if(isFacingRight)
    //    {
    //        dashPower = dashStrength;
    //    }
    //    else if (!isFacingRight)
    //    {
    //        dashPower = -dashStrength;
    //    }

    //    if (Input.GetKeyDown(KeyCode.LeftShift))
    //    {
    //        rb.velocity = new Vector2(rb.velocity.x + dashPower, rb.velocity.y);
    //    }
    //}
}
