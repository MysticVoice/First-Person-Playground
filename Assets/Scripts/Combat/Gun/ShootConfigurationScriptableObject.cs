using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    [CreateAssetMenu(fileName ="Shoot Config", menuName = "Guns/Shoot Configuration",order = 2)]
    public class ShootConfigurationScriptableObject : ScriptableObject
    {
        public LayerMask hitMask;
        public Vector3 spread = Vector3.one*0.1f;
        public float fireRate = 0.25f;
    }
}
