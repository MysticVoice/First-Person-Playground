using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MysticVoice
{
    public class HeldItemInputs : MonoBehaviour
    {
        IHeldItem heldItem;
        public InputActionReference primaryInput;
        public InputActionReference secondaryInput;
        public InputActionReference reloadInput;

        // Start is called before the first frame update
        void Start()
        {
            heldItem = GetComponentInChildren<IHeldItem>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GetPrimaryInput()) heldItem.PrimaryUse();
            if (GetSecondaryInput()) heldItem.SecondaryUse();
            if (GetReloadInput()) heldItem.Reload();
        }

        public void OnHeldItemSwitch()
        {
            heldItem = GetComponent<IHeldItem>();
        }

        public bool GetPrimaryInput()
        {
            return GetBinaryInput(primaryInput);
        }
        public bool GetSecondaryInput()
        { 
            return GetBinaryInput(secondaryInput);
        }
        public bool GetReloadInput()
        {
            return GetBinaryInput(reloadInput);
        }

        public bool GetBinaryInput(InputActionReference input)
        {
            if (input == null) return false;
            return input.action.ReadValue<float>() > 0;
        }

        private void OnEnable()
        {
            primaryInput?.action.Enable();
            secondaryInput?.action.Enable();
            reloadInput?.action.Enable();
        }

        private void OnDisable()
        {
            primaryInput?.action.Disable();
            secondaryInput?.action.Disable();
            reloadInput?.action.Disable();
        }
    }
}
