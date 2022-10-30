using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class ProjectileSpawner
    {
        public static void SpawnProjectile(Transform t, GameObject projectile)
        {
            SpawnProjectile(t,projectile,Vector3.zero);
        }
        public static void SpawnProjectile(Transform t, GameObject projectile, Vector3 offset)
        {
            GameObject proj = MonoBehaviour.Instantiate(projectile);
            proj.transform.position = t.position + offset;
            proj.transform.rotation = t.rotation;
        }
    }
}
