using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace MysticVoice
{
    public class DealDamage : MonoBehaviour
    {
        [SerializeField]
        LayerMask damageMask;
        [SerializeField]
        private GameObject damageText;
        [SerializeField]
        private int damage;
        [SerializeField]
        private DamageType damageType;
        private void OnTriggerEnter(Collider other)
        {
            ITakeDamage damageable = other.gameObject.GetComponent<ITakeDamage>();
            if (damageable != null)
            {
                damageable.Damage(damage,damageType);
                GameObject dt = Instantiate(damageText);
                dt.transform.position = transform.position;
                dt.transform.rotation = transform.rotation;
                TextMeshPro tmp = dt.GetComponent<TextMeshPro>();
                tmp.color = damageType.color;
                tmp.text = damage.ToString();
                Destroy(this.gameObject);
            }
            if (damageMask == (damageMask | (1 <<other.gameObject.layer))) Destroy(this.gameObject);
        }
    }
}
