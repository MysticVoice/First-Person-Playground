using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class Projectile : MonoBehaviour
    {
        public float speed;
        public int projectileLifetime = 3;

        public void Awake()
        {
            Destroy(gameObject,projectileLifetime);
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
    }
}
