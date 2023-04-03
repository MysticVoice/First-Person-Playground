using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class ItemCostCondition : MonoBehaviour, IHaveACondition
    {
        public Item item;
        public int ammount;


        public bool CheckCondition()
        {
            return false;
        }

        public bool CheckCondition(Transform caller)
        {
            Inventory i = caller.GetComponent<InventoryHolder>().GetInventory();
            if (i.GetItemAmmount(item) < ammount)
            {
                return false;
            }
            i.RemoveItem(item, ammount);
            return true;
        }
    }
}
