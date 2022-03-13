using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner
{
    public static void SpawnProjectile(FirePoint firePoint,GameObject projectile)
    {
        GameObject proj = MonoBehaviour.Instantiate(projectile);
        proj.transform.position = firePoint.transform.position;
        proj.transform.rotation = firePoint.transform.rotation;
    }
}
