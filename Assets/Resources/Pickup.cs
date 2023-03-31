using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{

    public class Pickup : MonoBehaviour
    {
        public Inventory inventory;

        private void OnTriggerEnter(Collider other)
        {
            // Check if the collider is an inventory holder
            InventoryHolder inventoryHolder = other.gameObject.GetComponent<InventoryHolder>();
            if (inventoryHolder == null)
            {
                return;
            }

            // Transfer the inventory to the inventory holder
            Inventory.MergeInventory(inventoryHolder.GetInventory(),inventory);

            // Destroy the pickup object
            Destroy(gameObject);
        }
    }
}
