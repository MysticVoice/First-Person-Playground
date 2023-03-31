using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public interface ITakeDamage
    {
        public void Damage(float damage);
        public void Damage(float damage,DamageType damageType);
    }
}
