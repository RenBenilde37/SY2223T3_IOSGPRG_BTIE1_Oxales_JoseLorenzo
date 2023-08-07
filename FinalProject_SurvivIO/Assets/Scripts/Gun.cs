using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] GameObject bulletPrefab;

    public float bulletVelocity;

    public WeaponType weaponType;

    public float shotgunSpread;
    public int pelletCount;

    public bool isAutoActive;
    [SerializeField] public float autoFireRate;

    public Ammo gunAmmo;

    public bool infiniteAmmo;

    public enum WeaponType
    {
        Pistol,
        Rifle,
        Shotgun
    };

    // Start is called before the first frame update
    private void Start()
    {
        if (gameObject.GetComponent<Gun>().weaponType == WeaponType.Pistol)
        {
            gunAmmo = player.GetComponent<PlayerInventory>().ammoPistol;
        }

        else if (weaponType == WeaponType.Rifle)
        {
            gunAmmo = player.GetComponent<PlayerInventory>().ammoRifle;
        }

        else if (weaponType == WeaponType.Shotgun)
        {
            gunAmmo = player.GetComponent<PlayerInventory>().ammoShotgun;
        }

        Debug.Log(gunAmmo.ToString() + " Loaded.");
    }

    public void Fire()
    {
        if (!gunAmmo.isClipEmpty() || infiniteAmmo)
        {
            GameObject bullet;
            Vector3 playerPosition = gameObject.transform.position;
            Quaternion playerRotation = gameObject.transform.rotation;


            if (weaponType != WeaponType.Shotgun)
            {
                bullet = Instantiate(bulletPrefab, playerPosition, playerRotation);
                bullet.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * bulletVelocity;

                StartCoroutine("CO_AutoFire");
            }

            else if (weaponType == WeaponType.Shotgun)
            {
                for (int i = 0; i < pelletCount; i++)
                {
                    bullet = Instantiate(bulletPrefab, playerPosition, playerRotation);
                    bullet.transform.Rotate(0, 0, Random.Range(-shotgunSpread, shotgunSpread));
                    bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * (bulletVelocity * Random.Range(0.8f, 1f));
                }
            }

            gunAmmo.RemoveAmmoFromClip();
            Debug.Log("Gun Fired. " + gunAmmo.GetCurrentClipCapacity() + " remaining in Clip. " + gunAmmo.GetCurrentAmmoReserve() + " Remaining in Reserves.");
        }

        else if (gunAmmo.isClipEmpty())
        {
            Debug.Log("Gun Empty!");

            if (player.GetComponent<PlayerController>())
                player.GetComponent<PlayerController>().Reload();

            if (player.GetComponent<EnemyControl>())
                player.GetComponent<EnemyControl>().Reload();
        }
    }

    public void Reload()
    {
        if(infiniteAmmo)
            gunAmmo.SetInfiniteAmmo();

        gunAmmo.Reload();
        Debug.Log("Gun Reloaded!");
    }

    public void SetAutomatic(bool isAuto)
    {
        isAutoActive = isAuto;
    }

    IEnumerator CO_AutoFire()
    {
        yield return new WaitForSeconds(autoFireRate);
        if (weaponType == WeaponType.Rifle && isAutoActive)
        {
            Fire();
        }
    }
}
