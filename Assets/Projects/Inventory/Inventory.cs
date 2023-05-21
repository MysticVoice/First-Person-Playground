using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{

    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
    public class Inventory : ScriptableObject
    {
        public int slotCount = 10;  // Number of slots in the inventory
        private List<ItemSlot> itemSlots; 
        public List<ItemSlot> ItemSlots
        {
            get {
                if (itemSlots == null)
                {
                    itemSlots = new List<ItemSlot>();
                    for(int i = 0;i<slotCount;i++)
                    {
                        itemSlots.Add(new ItemSlot());
                    }
                }
                return itemSlots;   
            }
        }

        // Add or modify an item in the inventory
        public int AddItem(Item item, int quantity)
        {
            if (item == null || quantity == 0) return quantity;
            if (item.maxStack > 1)
            {
                // Check if there's an available slot with the same item
                ItemSlot stackableSlot = GetStackableSlot(item);
                if (stackableSlot != null)
                {
                    int rest = stackableSlot.AddItem(item,quantity);
                    return RecurseAdd(item, rest);
                }
            }

            // Check if there's an available slot for a new item
            ItemSlot emptySlot = GetEmptySlot();
            if (emptySlot != null)
            {
                int rest = emptySlot.AddItem(item, quantity);
                return RecurseAdd(item, rest);
            }

            Debug.Log("Inventory is full.");
            return quantity;
        }

        private int RecurseAdd(Item item, int quantity)
        {
            if (quantity == 0) return 0;
            else return AddItem(item, quantity);
        }

        // Remove an item from the inventory
        public void RemoveItem(Item item, int quantity)
        {
            if (!(GetQuantity(item) >= quantity)) return;
            ItemSlot slot = FindItemSlot(item);
            if (slot == null) return;

            if (slot.quantity < quantity)
            {
                quantity -= slot.quantity;
                RemoveItem(item, quantity);
            }
            slot.ModifyItemQuantity(-quantity);
            if (slot.IsEmpty())
            {
                slot.item = null;
                slot.quantity = 0;
            }
        }

        private ItemSlot GetStackableSlot(Item item)
        {
            foreach (ItemSlot itemSlot in ItemSlots)
            {
                if (itemSlot.HasItem() && itemSlot.GetItem().itemId == item.itemId &&
                    itemSlot.GetQuantity() < item.maxStack)
                {
                    return itemSlot;
                }
            }
            return null;
        }

        // Find an empty slot in the inventory
        private ItemSlot GetEmptySlot()
        {
            foreach (ItemSlot itemSlot in ItemSlots)
            {
                if (itemSlot.IsEmpty())
                {
                    return itemSlot;
                }
            }
            return null;
        }

        // Find a slot containing the specified item
        private ItemSlot FindItemSlot(Item item)
        {
            foreach (ItemSlot itemSlot in ItemSlots)
            {
                if (itemSlot.HasItem() && itemSlot.GetItem().itemId == item.itemId)
                {
                    return itemSlot;
                }
            }
            return null;
        }

        public int GetQuantity(Item item)
        {
            int quantity = 0;
            foreach(ItemSlot itemSlot in ItemSlots)
            {
                if (itemSlot.item == item) quantity += itemSlot.GetQuantity();
            }
            return quantity;
        }

        public static void MergeInventory(Inventory targetInventory, Inventory sourceInventory)
        {
            foreach(ItemSlot slot in sourceInventory.ItemSlots)
            {
                if (slot != null && slot.item != null)
                {
                    int rest = targetInventory.AddItem(slot.GetItem(), slot.GetQuantity());
                    slot.quantity = rest;
                }
            }
        }

        public bool IsEmpty()
        {
            foreach(ItemSlot slot in ItemSlots)
            {
                if(!slot.IsEmpty()) return false;
            }
            return true;
        }
    }
}
