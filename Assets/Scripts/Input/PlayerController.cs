using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float verticalSpeed = 10f;
    [SerializeField]
    private float horizontalSpeed = 10f;
    [SerializeField]
    private float clampAngle = 60f;
    [SerializeField]
    private Transform lookDirection;
    [SerializeField]
    private bool invertY;
    [SerializeField]
    private int coyoteFrames = 5;

    private bool skipFrame;

    private IAmUseable weapon;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Vector2 movement;
    private bool playerJumpedThisFrame;
    private Vector2 deltaInput;
    private int coyoteCounter = 5;

    public int extraJumps = 1;
    private int jumpsLeft;

    public ScriptableBoolEvent jumpInput;
    public ScriptableBoolEvent fireInput;
    public ScriptableVector2Event lookEvent;
    public ScriptableVector2Event moveEvent;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        movement = Vector2.zero;
        deltaInput = Vector2.zero;
        playerJumpedThisFrame = false;
        weapon = GetComponentInChildren<IAmUseable>();
        jumpInput.OnTrigger += SetJumpState;
        ResetJumps();
    }

    private void SetJumpState(bool value)
    {
        if (!playerJumpedThisFrame) playerJumpedThisFrame = value;
    }

private void Update()
    {
        GatherInput();
        Look(deltaInput);
    }

    private void GatherInput()
    {
        deltaInput = lookEvent.value;
        movement = moveEvent.value;
    }

    void FixedUpdate()
    {
        if (!skipFrame)
        {
            GroundCheck();
            Move(movement);
            Jump();
        }
        else skipFrame = false;
        weapon.Use(fireInput.value);
    }

    private void Jump()
    {
        PerformJump();
        PlayerSteppedOffLedge();
        playerJumpedThisFrame = false;
        controller.Move(playerVelocity * Time.fixedDeltaTime);
    }

    private void Move(Vector2 movement)
    {
        
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = move.normalized;
        controller.Move(transform.TransformVector(move) * Time.fixedDeltaTime * playerSpeed);
    }

    private void GroundCheck()
    {
        groundedPlayer = controller.isGrounded;
        if ((groundedPlayer && playerVelocity.y < 0) || coyoteCounter > 0)
        {
            ResetJumps();
            playerVelocity.y = 0f;
            if (!groundedPlayer)
            {
                coyoteCounter--;
                groundedPlayer = true;
            }
            else
            {
                coyoteCounter = coyoteFrames;
            }
        }
    }

    private void PerformJump()
    {
        if (playerJumpedThisFrame && jumpsLeft > 0)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            coyoteCounter = 0;
            jumpsLeft--;
        }
    }

    private void PlayerSteppedOffLedge()
    {
        if (coyoteCounter <= 0)
        {
            playerVelocity.y += gravityValue * Time.fixedDeltaTime;
            if (jumpsLeft == extraJumps+1) jumpsLeft--;
        }
    }

    private void Look(Vector2 deltaInput)
    {
        float horizontal = deltaInput.x * horizontalSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(0,horizontal,0);
        float vertical = deltaInput.y * Time.deltaTime * verticalSpeed;
        if (invertY) vertical = -vertical;
        vertical += ((lookDirection.localRotation.eulerAngles.x+90)%360)-90;
        vertical = Mathf.Clamp(vertical,-clampAngle,clampAngle);
        lookDirection.localRotation = Quaternion.Euler(vertical, 0, 0);
    }

    private void ResetJumps()
    {
        jumpsLeft = extraJumps+1;
    }


    public void SkipNextFrame()
    {
        skipFrame = true;
    }
}
