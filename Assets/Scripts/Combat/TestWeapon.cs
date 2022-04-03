using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : MonoBehaviour,IFire
{
    private FirePoint firePoint;
    public GameObject projectile;

    public void OnEnable()
    {
        firePoint = GetComponentInChildren<FirePoint>();
    }

    public void Fire(bool fireInput)
    {
        ProjectileSpawner.SpawnProjectile(firePoint,projectile);
    }
}
