using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MysticVoice
{
    public class PlayerCharacterInput : MonoBehaviour
    {
        ExpandedCharacterController character;
        public InputActionReference jump;
        public InputActionReference move;
        public InputActionReference look;
        // Start is called before the first frame update
        void Start()
        {
            character = GetComponent<ExpandedCharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            character.SetJumpInput(GetJumpInput());
            character.SetMoveInput(GetMoveInput());
            character.SetLookInput(GetLookInput());
        }

        private void OnEnable()
        {
            move.action.Enable();
            jump.action.Enable();
            look.action.Enable();
        }

        public bool GetJumpInput()
        {
            return jump.action.ReadValue<float>() > 0;
        }

        public Vector2 GetMoveInput()
        {
            return move.action.ReadValue<Vector2>();
        }

        public Vector2 GetLookInput()
        {
            return look.action.ReadValue<Vector2>();
        }
    }
}
