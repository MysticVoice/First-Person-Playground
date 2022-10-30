using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class ExpandedCharacterController : MonoBehaviour
    {
        [SerializeField]
        public float playerSpeed = 10.0f;
        [SerializeField]
        public float jumpHeight = 1.0f;
        [SerializeField]
        public float gravityValue = -9.81f;
        [SerializeField]
        public float verticalSpeed = 10f;
        [SerializeField]
        public float horizontalSpeed = 10f;
        [SerializeField]
        public float clampAngle = 60f;
        [SerializeField]
        public Transform lookDirection;
        [SerializeField]
        public bool invertY;
        [SerializeField]
        public int coyoteFrames = 5;

        public int dashFrames = 15;
        public float dashMultiplier = 5;

        private CharacterController controller;
        public Vector3 momentum = Vector3.zero;
        public Vector3 movement = Vector3.zero;
        private Vector2 moveInput = Vector2.zero;
        private Vector2 look = Vector2.zero;

        //public ScriptableBoolEvent jumpInput;
        //public ScriptableVector2Event lookEvent;
        //public ScriptableVector2Event moveEvent;

        public int extraJumps = 1;
        private int jumpsLeft;
        public bool playerJumpedThisFrame;
        public bool skipFrame;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
            jumpsLeft = 0;

        }

        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void FixedUpdate()
        {
            if (!skipFrame)
            {
                controller.Move(CalculateMovement());
                if (playerJumpedThisFrame && !CanJump()) playerJumpedThisFrame = false;
            }
            skipFrame = false;
        }

        public void StandardMovement()
        {
            movement.x = moveInput.normalized.x;
            movement.z = moveInput.normalized.y;
        }

        private Vector3 CalculateMovement()
        {
            Vector3 calculatedMovement = transform.TransformVector((movement) * playerSpeed * Time.fixedDeltaTime);
            calculatedMovement += transform.TransformVector(momentum * Time.fixedDeltaTime);
            return calculatedMovement;
        }

        public void GroundedDownForce()
        {
            if (RaycastGrounded()) movement.y = -1;
            else movement.y = 0;
        }

        public bool RaycastGrounded()
        {
            float floorDistanceFromFoot = 1;
            RaycastHit hit;
            if (Physics.Raycast(transform.localPosition + -transform.up * 0.9f, -transform.up, out hit, floorDistanceFromFoot))
            {
                return true;
            }
            return false;
        }

        private void Update()
        {
            Look(look);
        }

        public void SetMoveInput(Vector2 moveInput)
        {
            this.moveInput = moveInput;
        }

        public void AddMomentum(Vector3 momentum) => this.momentum = momentum;
        public void AddMovement(Vector3 movement) => this.movement = movement;
        public void SetMomentum(Vector3 momentum) => this.momentum = momentum;
        public void SetMovement(Vector3 movement) => this.movement = movement;

        public void ResetVerticalMovement()
        {
            movement.y = 0;
        }

        public bool IsGrounded()
        {
            return controller.isGrounded;
        }

        public void ResetJumps()
        {
            jumpsLeft = extraJumps + 1;
        }

        public void SetJumpInput(bool jumpInput)
        {
            if (!playerJumpedThisFrame) playerJumpedThisFrame = jumpInput;
        }
        public void SetLookInput(Vector2 lookInput)
        {
            look = lookInput;
        }

        public bool CanJump()
        {
            return jumpsLeft > 0;
        }

        public void Jump()
        {
            momentum.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            jumpsLeft--;
        }

        public void SteppedOffLedge()
        {
            jumpsLeft--;
            ResetVerticalMovement();
        }

        public void Fall()
        {
            momentum.y += gravityValue * Time.fixedDeltaTime;
            //if (momentum.magnitude > 2f) momentum -= momentum.normalized * (1 - AirResistance.CalculateAirResistance(momentum.magnitude, weight, area, 1.2f, 1f));
        }

        private void Look(Vector2 deltaInput)
        {
            float horizontal = deltaInput.x * horizontalSpeed * Time.deltaTime;
            transform.localRotation *= Quaternion.Euler(0, horizontal, 0);
            float vertical = deltaInput.y * Time.deltaTime * verticalSpeed;
            if (invertY) vertical = -vertical;
            vertical += ((lookDirection.localRotation.eulerAngles.x + 90) % 360) - 90;
            vertical = Mathf.Clamp(vertical, -clampAngle, clampAngle);
            lookDirection.localRotation = Quaternion.Euler(vertical, 0, 0);
        }
    }
}
