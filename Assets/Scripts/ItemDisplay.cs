using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MysticVoice
{
    public class ItemDisplay : MonoBehaviour
    {
        public Item item;
        private Inventory inventory;
        private TMP_Text text;

        private void Start()
        {
            inventory = FindObjectOfType<PlayerCharacterInput>().GetComponent<InventoryHolder>().GetInventory();
            GetComponent<Image>().sprite = item.resource_image;
            text = GetComponentInChildren<TMP_Text>();
        }

        private void Update()
        {
            text.text = inventory.GetQuantity(item).ToString();
        }
    }
}
