using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.UI.Image;
using UnityEngine.InputSystem.HID;

namespace MysticVoice
{
    public enum FireMode { projectile, hitscan}
    public class Weapon : MonoBehaviour, IFire, IDataPersistence, IHeldItem
    {
        public bool automatic = true;
        public int magazineSize = 30;
        public float fireRate = 1;
        public bool useProjectiles = true;
        public FireMode fireMode = FireMode.projectile;
        public event System.Action<string> OnAmmoChanged;

        private int bulletsInMag;

        public float reloadTime;

        private FirePoint firePoint;
        public GameObject projectile;

        public Transform gunModel;
        public Transform gunModelDefaultPos;

        public UnityAction<RaycastHit> hitEvent;

        public bool fireInput { get; set; }
        public bool reloadInput { get; set; }

        private void Start()
        {
            //bulletsInMag = magazineSize;
            UpdateAmmoText();
        }

        public void Fire(bool input)
        {
            if (fireMode == FireMode.projectile) ProjectileSpawner.SpawnProjectile(Camera.main.transform, projectile, Camera.main.transform.forward * 1f);
            else if (fireMode == FireMode.hitscan)
            {
                RaycastHit hit;
                Hitscan.Fire(Camera.main.transform,out hit);
                hitEvent?.Invoke(hit);
            }
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

        public void LoadData(GameData data)
        {
            this.bulletsInMag = data.ammo;
        }

        public void SaveData(ref GameData data)
        {
            data.ammo = this.bulletsInMag;
        }

        public void PrimaryUse()
        {
            fireInput = true;
        }

        public void SecondaryUse()
        {
            
        }

        public void Reload()
        {
            reloadInput = true;
        }

        public void ResetInputs()
        {
            reloadInput = false;
            fireInput = false;
        }
    }
}
