using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    [CreateAssetMenu(fileName = "Loot Table",menuName ="Scriptable Objects/Loot Table")]
    public class LootTable : ScriptableObject
    {
        [SerializeField]
        private List<LootTableEntry> lootTable;
        
        public List<LootTableEntry> GetLootTable()
        {
            if (lootTable == null) lootTable = new List<LootTableEntry>();
            return lootTable;
        }

        public void AddLootTableEntry(LootTableEntry entry)
        {
            GetLootTable().Add(entry);
        }

        public void AddLootTableEntry(Item item, int ammountMin,int ammountMax, int weight)
        {
            LootTableEntry entry = new LootTableEntry();
            entry.item = item;
            entry.ammountMin = ammountMin;
            entry.ammountMax = ammountMax;
            entry.weight = weight;
            GetLootTable().Add(entry);
        }

        public void RemoveLootTableEntry(int index)
        {
            GetLootTable().RemoveAt(index);
        }
        public void RemoveLootTableEntry(LootTableEntry entry)
        {
            GetLootTable().Remove(entry);
        }

        public int GetRandomLootItem(out Item item)
        {
            // Initialize a sum of weights and a list of entries with non-zero weights
            int weightSum = 0;
            List<LootTableEntry> validEntries = new List<LootTableEntry>();
            foreach (LootTableEntry entry in GetLootTable())
            {
                if (entry.weight > 0)
                {
                    validEntries.Add(entry);
                    weightSum += entry.weight;
                }
            }

            // If there are no entries with non-zero weights, return 0 and set the item to null
            if (weightSum == 0)
            {
                item = null;
                return 0;
            }

            // Generate a random number between 0 and the sum of weights
            int randomNumber = Random.Range(0, weightSum);

            // Iterate through the valid entries and decrement the random number by the weight of each entry
            // When the random number is less than zero, return a random number of items within the specified range and the item from that entry
            foreach (LootTableEntry entry in validEntries)
            {
                randomNumber -= entry.weight;
                if (randomNumber < 0)
                {
                    item = entry.item;
                    return Random.Range(entry.ammountMin, entry.ammountMax + 1);
                }
            }

            // If the code execution reaches this point, return 0 and set the item to null
            item = null;
            return 0;
        }

        public Inventory GetRandomLoot(int lootItems)
        {
            Inventory inventory = ScriptableObject.CreateInstance<Inventory>();
            for (int i = 0; i < lootItems; i++)
            {
                Item item;
                int ammount = GetRandomLootItem(out item);
                inventory.AddItem(item, ammount);
            }
            return inventory;
        }
    }
}
