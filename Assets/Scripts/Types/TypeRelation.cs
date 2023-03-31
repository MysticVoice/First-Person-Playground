using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    [CreateAssetMenu(fileName ="Type Relation",menuName = "Scriptable Objects/Types/Type Relation")]
    public class TypeRelation : ScriptableObject
    {
        public float multiplier;
        public ValueType AttackingType;
        public ValueType DefendingType;
    }
}
