using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    [CreateAssetMenu(fileName ="Damage Type",menuName = "Scriptable Objects/Types/Damage Type")]
    public class DamageType : ValueType
    {
        public List<TypeRelation> typeRelations;

        public float GetModifier(HealthType healthType)
        {
            for (int i = 0; i < typeRelations.Count; i++)
            {
                if (healthType == typeRelations[i].DefendingType) return typeRelations[i].multiplier; 
            }
            return 1;
        }


    }
}
