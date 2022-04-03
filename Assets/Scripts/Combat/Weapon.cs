using UnityEngine;

public class Weapon : MonoBehaviour,IFire
{
    public bool automatic = true;
    public int magazineSize = 30;
    public float fireRate = 1;
    public bool useProjectiles = true;

    private int bulletsInMag;

    public float reloadTime;

    private FirePoint firePoint;
    public GameObject projectile;

    public Transform gunModel;
    public Transform gunModelDefaultPos;

    private void Start()
    {
        bulletsInMag = magazineSize;
    }

    public void Fire(bool input)
    {
        if (useProjectiles) ProjectileSpawner.SpawnProjectile(firePoint, projectile);
        bulletsInMag--;
    }

    public void OnEnable()
    {
        firePoint = GetComponentInChildren<FirePoint>();
    }

    public float TimeToFire(float fireRate) => 1 / fireRate;
    public float GetNextFireTime(float fireRate) => Time.time + TimeToFire(fireRate);
    public float GetNextReloadTime(float reloadTime) => Time.time + reloadTime;
    public bool MagHasBullets() => bulletsInMag != 0;
    public void FillMagazine() => bulletsInMag = magazineSize;
}
