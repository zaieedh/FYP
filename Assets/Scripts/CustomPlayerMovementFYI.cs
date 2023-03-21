using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Player movement script
public class CustomPlayerMovementFYI : MonoBehaviour
{
    /// <summary>
    /// Movement speed of player
    /// </summary>
    [Header("Movement")]
    public float moveSpeed;
    /// <summary>
    /// Amount of ground drag
    /// </summary>
    public float groundDrag;
    /// <summary>
    /// Force of player's jumping
    /// </summary>
    public float jumpForce;
    /// <summary>
    /// Cooldown between player's jumps
    /// </summary>
    public float jumpCooldown;
    /// <summary>
    /// Multiplier for air resistance
    /// </summary>
    public float airMultiplier;
    /// <summary>
    /// Check if player is ready to jump
    /// </summary>
    bool readyToJump;
    /// <summary>
    /// Walk speed of player
    /// </summary>
    [HideInInspector] public float walkSpeed;
    /// <summary>
    /// Sprint speed of player
    /// </summary>
    [HideInInspector] public float sprintSpeed;

    /// <summary>
    /// Binding a key used to jump
    /// </summary>
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    /// <summary>
    /// Height of player
    /// </summary>
    [Header("Ground Check")]
    public float playerHeight;
    /// <summary>
    /// Mask describing a layer
    /// </summary>
    public LayerMask whatIsGround;
    /// <summary>
    /// Checking if grounded
    /// </summary>
    public bool grounded;
    /// <summary>
    /// Player's orientation
    /// </summary>
    public Transform orientation;

    /// <summary>
    /// Amount of horizontal input
    /// </summary>
    float horizontalInput;
    /// <summary>
    /// Amount of vertical input
    /// </summary>
    float verticalInput;
    /// <summary>
    /// Vector of direction player is moving to
    /// </summary>
    Vector3 moveDirection;
    /// <summary>
    /// Instance of rigidbody object attached to player
    /// </summary>
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        /*rb.freezeRotation = true;*/

        readyToJump = true;
    }

    private void Update()
    {
        if (!GameManager.isMenuOpened)
        {
            // ground check
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

            MyInput();
            SpeedControl();

            // handle drag
            if (grounded)
                rb.drag = groundDrag;
            else
                rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.isMenuOpened)
        {
            MovePlayer();
        }
    }

    /// <summary>
    /// Processing player inputs
    /// </summary>
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
			readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    /// <summary>
    /// Move player
    /// </summary>
    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }
    /// <summary>
    /// Control players speed, lower velocity if its too high
    /// </summary>
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    /// <summary>
    /// Proceed jump, addiing force to player
    /// </summary>
    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    /// <summary>
    /// Changing state of player's jump, to set it to ready
    /// </summary>
    private void ResetJump()
    {
        readyToJump = true;
    }
}