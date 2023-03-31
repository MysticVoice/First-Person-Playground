using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class DropItemsFromLootTable : MonoBehaviour
    {
        [SerializeField]
        public GameObject prefabToSpawn;
        [SerializeField]
        private LootTable loot;
        [SerializeField]
        private int lootRolls;
        public void DropItems()
        {
            GameObject dropItem = Instantiate(prefabToSpawn);
            dropItem.transform.position = transform.position;
            dropItem.transform.rotation = transform.rotation;
            dropItem.name = "Dropped Item";
            dropItem.transform.parent = FindObjectOfType<DropParent>().transform;
            Pickup pickup = dropItem.AddComponent<Pickup>();
            pickup.inventory = loot.GetRandomLoot(lootRolls);
        }
    }
}
