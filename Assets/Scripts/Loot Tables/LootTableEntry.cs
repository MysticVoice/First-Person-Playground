using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    [System.Serializable]
    public class LootTableEntry
    {
        [SerializeField]
        public Item item;
        [SerializeField]
        public int ammountMin;
        [SerializeField]
        public int ammountMax;
        [SerializeField]
        public int weight;
    }
}
