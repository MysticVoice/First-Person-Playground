using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MysticVoice
{
    public class InventoryControll : MonoBehaviour
    {
        private GameObject inventoryObject;

        public InputActionReference toggleInventory;

        private bool toggleInventoryInput;
        public GameObject InventoryObject 
        { 
            get { 
                if (inventoryObject == null) inventoryObject = GetComponentInChildren<InventoryHolder>().gameObject;
                return inventoryObject; 
            } 
        }

        private void Update()
        {
            toggleInventoryInput = ReadToggleInventoryInput();
        }

        private void FixedUpdate()
        {
            if (toggleInventoryInput) { Toggle(); }
        }

        private void Toggle()
        {
            InventoryObject.SetActive(!InventoryObject.activeSelf);
        }
        public bool ReadToggleInventoryInput()
        {
            return toggleInventory.action.ReadValue<float>() > 0;
        }

    }
}
