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
    [SerializeField] private Transform enemyCheck;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask oneWayPlatformLayer;

    // Gizmo size parameters
    private float groundCheckWidth = 1.16f;
    private float groundCheckHeight = 0.2f;

    private float enemyCheckWidth = 1;
    private float enemyCheckHeight = 3;

    [Header("------Audio Clips------")]
    public AudioClip coinCollected;
    public AudioClip foodCollected;
    public AudioClip gotStabbed;

    AudioSource audioSource;

    HealthManagerScript healthManager;

    GemManager gemManager;

    public List<ModData> onLeftClickMods; //every mod to be triggered on left click 

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

        Flip();

        //_____________________
        //Code Snippet section
        if (Input.GetMouseButtonDown(0) && onLeftClickMods != null)
        {
            foreach (ModData m in onLeftClickMods)
            {
                m.Execute();
            }
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

    private bool IsGrounded2()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(groundCheckWidth, groundCheckHeight), 0, oneWayPlatformLayer);
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


        // Set the color with custom alpha.
        Gizmos.color = new Color(0f, 1f, 0f, 10); // Green with custom alpha

        // Draw the cube.
        Gizmos.DrawCube(enemyCheck.position, new Vector3(enemyCheckWidth, enemyCheckHeight, 0));

        // Draw a wire cube outline.
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(enemyCheck.position, new Vector3(enemyCheckWidth, enemyCheckHeight, 0));
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

        if (IsGrounded() || IsGrounded2())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        //checking if you can double jump

        if (doubleJumpped && (IsGrounded() || IsGrounded2()))
        {
            doubleJumpped = false;
        }

        if ((!IsGrounded() || !IsGrounded2()) && !doubleJumpped) 
        { 
            canDoubleJump = true;
        }
        else if (doubleJumpped)
        {
            canDoubleJump = false;
        }

        //the actual jump

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && ((IsGrounded() || IsGrounded2()) || coyoteTimeCounter > 0f))
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

    //-------start public functions----------

    public void AddHealth(int amount)
    {
        healthManager.GainHealth(amount);
    }

    public void RemoveHealth(int amount)
    {
        healthManager.LoseHealth(amount);
        audioSource.clip = gotStabbed;
        audioSource.Play();
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

    public void AddMod(ModData mod)
    {
        onLeftClickMods.Add(mod);
    }

    public bool CanHitEnemy()
    {
        return Physics2D.OverlapBox(enemyCheck.position, new Vector2(enemyCheckWidth, enemyCheckHeight), 0, enemyLayer);
    }

}
