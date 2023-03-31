using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    [CreateAssetMenu(fileName = "Inventory", menuName ="Scriptable Objects/Inventory")]
    public class Inventory :ScriptableObject
    {
        private const int STACK_LIMIT = 100;

        private Dictionary<Item, List<InventoryItem>> items;
        public Dictionary<Item, List<InventoryItem>> Items
        {
            get 
            { 
                if(items == null) items = new Dictionary<Item, List<InventoryItem>>();
                return items;
            }
            set { items = value; }
        }

        public void AddItem(Item item, int ammount)
        {
            // Check if the item already exists in the inventory
            if (!Items.ContainsKey(item))
            {
                // If the item does not exist, add it to the inventory
                Items[item] = new List<InventoryItem>();
            }

            // Get the list of inventory items for the specified item
            List<InventoryItem> inventoryItems = Items[item];

            // Find the first inventory item with space available
            InventoryItem availableItem = null;
            foreach (InventoryItem inventoryItem in inventoryItems)
            {
                if (inventoryItem.ammount < STACK_LIMIT)
                {
                    availableItem = inventoryItem;
                    break;
                }
            }

            // If an available item is found, increment its ammount
            if (availableItem != null)
            {
                int remainingAmmount = STACK_LIMIT - availableItem.ammount;
                availableItem.ammount += Mathf.Min(remainingAmmount, ammount);
            }
            // If no available item is found, add a new inventory item to the list
            else
            {
                inventoryItems.Add(new InventoryItem(item, Mathf.Min(STACK_LIMIT, ammount)));
            }
        }

        public void RemoveItem(Item item, int ammount)
        {
            // Check if the item exists in the inventory
            if (!Items.ContainsKey(item))
            {
                return;
            }

            // Get the list of inventory items for the specified item
            List<InventoryItem> inventoryItems = Items[item];

            // Find the first inventory item with the specified ammount or more
            InventoryItem availableItem = null;
            foreach (InventoryItem inventoryItem in inventoryItems)
            {
                if (inventoryItem.ammount >= ammount)
                {
                    availableItem = inventoryItem;
                    break;
                }
            }

            // If an available item is found, decrement its ammount
            if (availableItem != null)
            {
                availableItem.ammount -= ammount;
                // If the ammount is less than or equal to zero, remove the item from the list
                if (availableItem.ammount <= 0)
                {
                    inventoryItems.Remove(availableItem);
                }
            }

            // If the list of inventory items for the specified item is empty, remove the item from the inventory
            if (inventoryItems.Count == 0)
            {
                Items.Remove(item);
            }
        }

        public int GetItemAmmount(Item item)
        {
            // Check if the item exists in the inventory
            if (!Items.ContainsKey(item))
            {
                return 0;
            }

            // Get the list of inventory items for the specified item
            List<InventoryItem> inventoryItems = items[item];

            // Calculate the total ammount of the item in the inventory
            int totalAmmount = 0;
            foreach (InventoryItem inventoryItem in inventoryItems)
            {
                totalAmmount += inventoryItem.ammount;
            }

            return totalAmmount;
        }

        #region Static Functions

        public static void MoveStack(Inventory sourceInventory, Item item, int ammount, Inventory targetInventory)
        {
            // Check if the source inventory contains the specified item
            if (sourceInventory.GetItemAmmount(item) < ammount)
            {
                return;
            }

            // Remove the stack of the item from the source inventory
            sourceInventory.RemoveItem(item, ammount);

            // Add the stack of the item to the target inventory
            targetInventory.AddItem(item, ammount);
        }
        public static void MoveStack(Inventory sourceInventory, Item item, Inventory targetInventory)
        {
            // Check if the source inventory contains the specified item
            if (sourceInventory.GetItemAmmount(item) >0)
            {
                return;
            }

            // Remove the stack of the item from the source inventory
            int itemAmmount = Mathf.Min(sourceInventory.GetItemAmmount(item),STACK_LIMIT);
            sourceInventory.RemoveItem(item, itemAmmount);

            // Add the stack of the item to the target inventory
            targetInventory.AddItem(item, itemAmmount);
        }

        public static void MergeInventory(Inventory targetInventory, Inventory sourceInventory)
        {
            // Iterate through the items in the source inventory
            foreach (KeyValuePair<Item, List<InventoryItem>> item in sourceInventory.items)
            {
                Item itemData = item.Key;
                List<InventoryItem> sourceInventoryItems = item.Value;

                // Iterate through the inventory items for the current item
                foreach (InventoryItem sourceInventoryItem in sourceInventoryItems)
                {
                    // Check if the item already exists in the target inventory
                    if (targetInventory.Items.ContainsKey(itemData))
                    {
                        // If the item already exists, add the ammount to the existing item
                        List<InventoryItem> targetInventoryItems = targetInventory.Items[itemData];
                        InventoryItem targetInventoryItem = targetInventoryItems[0];
                        targetInventoryItem.ammount += sourceInventoryItem.ammount;
                    }
                    else
                    {
                        // If the item does not exist, add a new item with the ammount to the target inventory
                        List<InventoryItem> newInventoryItemList = new List<InventoryItem>();
                        InventoryItem newInventoryItem = new InventoryItem(itemData,sourceInventoryItem.ammount);
                        newInventoryItemList.Add(newInventoryItem);
                        targetInventory.Items.Add(itemData, newInventoryItemList);
                    }
                }
            }

            // Clear the source inventory after the merge
            sourceInventory.Items.Clear();
        }
        #endregion

    }
}