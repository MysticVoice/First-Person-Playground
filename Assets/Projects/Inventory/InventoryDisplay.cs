using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace MysticVoice
{
    public class InventoryDisplay : MonoBehaviour
    {
        private UIDocument uiInventory;
        public VisualTreeAsset itemSlotTemplate;
        public InventoryHolder inventoryHolder;
        private Inventory inventory;
        private UIDocument UIInventory
        {
            get { 
                if(uiInventory == null)uiInventory = GetComponent<UIDocument>();
                return uiInventory;
            }
        }
        private void Start()
        {
            inventory = inventoryHolder.Inventory;
            foreach (ItemSlot slot in inventory.ItemSlots)
            {
                TemplateContainer itemSlotContainer = itemSlotTemplate.Instantiate();
                slot.slotImage = itemSlotContainer.Q<Button>();
                slot.slotImage.text = "";
                slot.UpdateSlotUI();
                UIInventory.rootVisualElement.Q("ItemRow").Add(itemSlotContainer);
            }
        }

        private void OnDisable()
        {
            /*foreach (ItemSlot slot in inventory.ItemSlots)
            {
                
                TemplateContainer template = slot.slotUI;
                UIInventory.rootVisualElement.Q("ItemRow").Remove(template);
                slot.slotUI = null;
                slot.UpdateSlotUI();
            }*/
        }
    }
}
