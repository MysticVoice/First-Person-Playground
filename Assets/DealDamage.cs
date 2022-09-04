using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class DealDamage : MonoBehaviour
    {
        [SerializeField]
        private int damage;
        private void OnTriggerEnter(Collider other)
        {
            ITakeDamage damageable = other.gameObject.GetComponent<ITakeDamage>();
            if (damageable != null)
            {
                damageable.Damage(damage);
                Destroy(this.gameObject);
            }
        }
    }
}
