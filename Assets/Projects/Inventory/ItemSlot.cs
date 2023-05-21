using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace MysticVoice
{
    [System.Serializable]
    public class ItemSlot
    {
        public Item item;  // Current item in the slot
        public int quantity;  // Current quantity of the item
        public Button slotImage;

        public int AddItem(Item newItem, int addedQuantity)
        {
            item = newItem;
            if(addedQuantity+quantity>item.maxStack)
            {
                quantity += addedQuantity;
                int rest = quantity - item.maxStack;
                quantity = item.maxStack;
                UpdateSlotUI();
                return rest;
            }
            quantity += addedQuantity;
            UpdateSlotUI();
            return 0;
            // Implement logic to visually represent the item and quantity in the slot
        }

        public void UpdateSlotUI()
        {
            if ((item == null) || (slotImage == null))
            {
                //slotImage.style.backgroundImage = ;
                return;
            }
            slotImage.style.backgroundImage = item.ItemImage;
        }

        private void OnClick(ClickEvent evt)
        {
            Debug.Log("The item" + item.itemName +"has been clicked");
        }

        public void ModifyItemQuantity(int deltaQuantity)
        {
            quantity += deltaQuantity;
            // Implement logic to visually update the item quantity in the slot
        }

        public void RemoveItem()
        {
            item = null;
            quantity = 0;
            UpdateSlotUI();
            // Implement logic to visually clear the slot
        }

        public Item GetItem()
        {
            return item;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public bool HasItem()
        {
            return item != null && quantity > 0;
        }

        public bool IsEmpty()
        {
            return item == null || quantity <= 0;
        }
    }

}
