using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class InventoryHolder : MonoBehaviour
    {
        [SerializeField]
        private Inventory inventory;

        private void Start()
        {
            InitializeInventory();
        }

        public Inventory GetInventory()
        {
            if(inventory==null) inventory = ScriptableObject.CreateInstance<Inventory>();
            return inventory;
        }
        public void SetInventory(Inventory inventory)
        {
            this.inventory = inventory;
        }

        private void InitializeInventory()
        {
             GetInventory();
        }
    }
}
