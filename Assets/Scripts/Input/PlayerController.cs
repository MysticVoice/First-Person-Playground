using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MysticVoice.Core;

namespace MysticVoice
{
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
        [Range(40, 100)]
        public float weight = 80;
        [Range(0, 2)]
        public float area = 1;


        private bool skipFrame;

        private IAmUseable heldItem;

        private CharacterController controller;
        private Vector3 playerMovement;
        private Vector3 playerMomentum;
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
            playerMovement = Vector3.zero;
            playerMomentum = Vector3.zero;
            heldItem = GetComponentInChildren<IAmUseable>();
            jumpInput.OnTrigger += SetJumpState;
            ResetJumps();
        }



        private void Update()
        {
            GatherInput();
            Look(deltaInput);
        }

        void FixedUpdate()
        {
            if (!skipFrame)
            {
                GroundCheck();
                Move(movement);
                Jump();

                controller.Move((playerMomentum + playerMovement) * Time.fixedDeltaTime);

                playerMovement.x = 0;
                playerMovement.z = 0;
                if (playerMomentum.magnitude > 2f) playerMomentum -= playerMomentum.normalized * (1 - AirResistance.CalculateAirResistance(playerMomentum.magnitude, weight, area, 1.2f, 1f));
                playerJumpedThisFrame = false;
            }
            else skipFrame = false;
            heldItem.Use(fireInput.value);
        }

        public void AddMomentum(Vector3 momentum)
        {
            playerMomentum += momentum;
        }

        public void AddMomentum(Vector3 dir, float force)
        {
            dir.Normalize();
            AddMomentum(dir * force);
        }

        private void GatherInput()
        {
            deltaInput = lookEvent.value;
            movement = moveEvent.value;
        }

        private bool IsGrounded()
        {
            float floorDistanceFromFoot = 1;
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.down * 0.9f, Vector3.down, out hit, floorDistanceFromFoot))
            {
                //Debug.Log(hit.point);
                return true;
            }
            return false;
        }

        private void Move(Vector2 movement)
        {
            Vector3 move = new Vector3(movement.x, 0, movement.y);
            if (move.x != 0 || move.z != 0)
            {
                move = move.normalized;
                move = move * Time.fixedDeltaTime * playerSpeed;
                playerMovement += transform.TransformVector(move);
            }
        }

        #region Grounding

        private void GroundCheck()
        {
            groundedPlayer = controller.isGrounded;
            if ((groundedPlayer && PlayerMovingDown()) || coyoteCounter > 0)
            {
                GroundPlayer();
            }
        }

        private bool PlayerMovingDown()
        {
            return playerMomentum.y + playerMomentum.y <= 0;
        }

        private void GroundPlayer()
        {
            ResetJumps();
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

        private void PlayerFreeFall()
        {
            if (coyoteCounter <= 0)
            {
                playerMomentum.y += gravityValue * Time.fixedDeltaTime;
                if (jumpsLeft == extraJumps + 1) jumpsLeft--;
            }
            else playerMomentum.y = 0;
        }

        #endregion Grounding

        #region Jump
        private void Jump()
        {
            if (playerJumpedThisFrame && jumpsLeft > 0) PerformJump();
            PlayerFreeFall();

        }
        private void PerformJump()
        {
            playerMomentum.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            coyoteCounter = 0;
            jumpsLeft--;
        }

        private void ResetJumps()
        {
            jumpsLeft = extraJumps + 1;
        }

        private void SetJumpState(bool value)
        {
            if (!playerJumpedThisFrame) playerJumpedThisFrame = value;
        }
        #endregion Jump

        private void Look(Vector2 deltaInput)
        {
            float horizontal = deltaInput.x * horizontalSpeed * Time.deltaTime;
            transform.rotation *= Quaternion.Euler(0, horizontal, 0);
            float vertical = deltaInput.y * Time.deltaTime * verticalSpeed;
            if (invertY) vertical = -vertical;
            vertical += ((lookDirection.localRotation.eulerAngles.x + 90) % 360) - 90;
            vertical = Mathf.Clamp(vertical, -clampAngle, clampAngle);
            lookDirection.localRotation = Quaternion.Euler(vertical, 0, 0);
        }

        public void SkipNextFrame()
        {
            skipFrame = true;
        }


    }
}
