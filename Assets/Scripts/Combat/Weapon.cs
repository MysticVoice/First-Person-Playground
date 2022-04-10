using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour,IFire
{
    public bool automatic = true;
    public int magazineSize = 30;
    public float fireRate = 1;
    public bool useProjectiles = true;
    public event System.Action<string> OnAmmoChanged;

    private int bulletsInMag;

    public float reloadTime;

    private FirePoint firePoint;
    public GameObject projectile;

    public Transform gunModel;
    public Transform gunModelDefaultPos;

    private void Start()
    {
        bulletsInMag = magazineSize;
        UpdateAmmoText();
    }

    public void Fire(bool input)
    {
        if (useProjectiles) ProjectileSpawner.SpawnProjectile(firePoint, projectile);
        UseBullet();
    }

    public void OnEnable()
    {
        firePoint = GetComponentInChildren<FirePoint>();
    }

    public float TimeToFire(float fireRate) => 1 / fireRate;
    public float GetNextFireTime(float fireRate) => Time.time + TimeToFire(fireRate);
    public float GetNextReloadTime(float reloadTime) => Time.time + reloadTime;
    public bool MagHasBullets() => bulletsInMag != 0;
    public void FillMagazine()
    {
        bulletsInMag = magazineSize;
        UpdateAmmoText();
    }
    public void UseBullet()
    {
        bulletsInMag--;
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        OnAmmoChanged?.Invoke(AmmoText());
    }

    public string AmmoText()
    {
        return "Ammo: " + bulletsInMag;
    }
}
