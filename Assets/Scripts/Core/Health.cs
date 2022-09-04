using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MysticVoice
{
    public class Health : MonoBehaviour, ITakeDamage
    {
        public float maxHealth = 100;
        private float health;

        public UnityEvent HealthReachedZeroEvent;

        private void Start()
        {
            health = maxHealth;
        }

        public void Damage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                HealthReachedZeroEvent?.Invoke();
            }
        }
    }
}
