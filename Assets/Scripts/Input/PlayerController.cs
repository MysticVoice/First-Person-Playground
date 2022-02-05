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
    private float clampAngle = 80f;
    [SerializeField]
    private Transform lookDirection;
    [SerializeField]
    private bool invertY;
    [SerializeField]
    private int coyoteFrames = 5;


    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;


    private Vector2 movement;
    private bool playerJumpedThisFrame;
    private Vector2 deltaInput;
    private int coyoteCounter = 5;
    public InputActionReference jumpInput;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        movement = Vector2.zero;
        deltaInput = Vector2.zero;
        playerJumpedThisFrame = false;
    }

    private void Update()
    {
        GatherInput();
    }

    private void GatherInput()
    {
        movement = inputManager.GetPlayerMovement();
        //if (!playerJumpedThisFrame) playerJumpedThisFrame = inputManager.PlayerJumpedThisFrame();
        if (!playerJumpedThisFrame) playerJumpedThisFrame = jumpInput.action.ReadValue<bool>();
        deltaInput = inputManager.GetMouseDelta();
    }

    void FixedUpdate()
    {
        Move(movement);
        Look(deltaInput);
    }

    private void Move(Vector2 movement)
    {
        groundedPlayer = controller.isGrounded;
        if ((groundedPlayer && playerVelocity.y < 0) || coyoteCounter>0)
        {
            playerVelocity.y = 0f;
            if (!groundedPlayer)
            {
                coyoteCounter--;
                groundedPlayer = true;
            }
            else coyoteCounter = coyoteFrames;
        }

        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = move.normalized;
        controller.Move(transform.TransformVector(move) * Time.fixedDeltaTime * playerSpeed);
        if (playerJumpedThisFrame && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            coyoteCounter = 0;
        }
        if(coyoteCounter <= 0)playerVelocity.y += gravityValue * Time.fixedDeltaTime;
        
        
        controller.Move(playerVelocity * Time.fixedDeltaTime);
        playerJumpedThisFrame = false;
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
}
