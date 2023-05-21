using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class InventoryHolder : MonoBehaviour, IDataPersistence
    {
        [SerializeField]
        private Inventory inventory;

        public Inventory Inventory { 
            get {
                if (inventory == null) inventory = ScriptableObject.CreateInstance<Inventory>();
                return inventory; 
            } 
        }

        [SerializeField]
        private bool playerInventory;

        private void Start()
        {
            //InitializeInventory();
        }

        public Inventory GetInventory()
        {
            return Inventory;
        }
        public void SetInventory(Inventory inventory)
        {
            this.inventory = inventory;
        }

        private void InitializeInventory()
        {
             GetInventory();
        }

        public void LoadData(GameData data)
        {
            inventory = data.inventory;
        }

        public void SaveData(ref GameData data)
        {
            data.inventory = Inventory;
        }
    }
}
