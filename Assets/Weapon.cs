using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour,IFire,IAmUseable
{
    const int FIRE = 0;
    const int RELOADING = 1;
    private int gunState = FIRE;

    public bool automatic = true;
    public int magazineSize = 30;
    public float fireRate = 1;
    public bool useProjectiles = true;

    private int bulletsInMag;
    private float fireTimer;
    private bool triggerReleased;

    public float reloadTime;
    private float reloadTimer;

    private FirePoint firePoint;
    public GameObject projectile;

    public Transform gunModel;
    public Transform gunModelDefaultPos;

    private void Start()
    {
        bulletsInMag = magazineSize;
        gunState = FIRE;

    }

    public void Use(bool input)
    {
        
        switch (gunState)
        {
            case FIRE:
                Fire(input);
                break;

            case RELOADING:
                if (CheckReloadTimer())
                {
                    FillMagazine();
                    gunState = FIRE;
                }
                break;
        }
    }

    public void Fire(bool input)
    {
        if (CheckConditionsToFire(input))
        {
            if (useProjectiles) ProjectileSpawner.SpawnProjectile(firePoint, projectile);
            triggerReleased = false;
            fireTimer = GetNextFireTime(fireRate);
            bulletsInMag--;
        }
        else if (!CheckMag())
        {
            Reload();
        }
        if (!input) triggerReleased = true;
    }

    private bool CheckConditionsToFire(bool fireInput)
    {
        return (automatic || triggerReleased) && fireInput && CheckFireTimer() && CheckMag();
    }

    private void Reload()
    {
        reloadTimer = GetNextReloadTime(reloadTime);
        gunState = RELOADING;
    }

    public void OnEnable()
    {
        firePoint = GetComponentInChildren<FirePoint>();
    }

    public float TimeToFire(float fireRate) => 1 / fireRate;

    public float GetNextFireTime(float fireRate)
    {
        return Time.time + TimeToFire(fireRate);
    }

    public float GetNextReloadTime(float reloadTime)
    {
        return Time.time + reloadTime;
    }

    public bool CheckFireTimer()
    {
        return Time.time >= fireTimer;
    }
    public bool CheckReloadTimer()
    {
        return Time.time >= reloadTimer;
    }
    public bool CheckMag()
    {
        return bulletsInMag != 0;
    }

    private void FillMagazine()
    {
        bulletsInMag = magazineSize;
    }

    
}
