using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] GameObject bulletPrefab;

    public float bulletVelocity;

    public bool isPistol;
    public bool isRifle;
    public bool isShotgun;

    public float shotgunSpread;
    public int pelletCount;

    public bool isAutoActive;
    [SerializeField] public float autoFireRate;

    public Ammo gunAmmo;

    // Start is called before the first frame update
    void Start()
    {
        if (isPistol)
        {
            gunAmmo = player.GetComponent<PlayerInventory>().ammoPistol;
        }

        else if (isRifle)
        {
            gunAmmo = player.GetComponent<PlayerInventory>().ammoRifle;
        }

        else if (isShotgun)
        {
            gunAmmo = player.GetComponent<PlayerInventory>().ammoShotgun;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire()
    {
        if (!gunAmmo.isClipEmpty())
        {
            GameObject bullet;
            Vector3 playerPosition = gameObject.transform.position;
            Quaternion playerRotation = gameObject.transform.rotation;


            if (isPistol || isRifle)
            {
                bullet = Instantiate(bulletPrefab, playerPosition, playerRotation);
                bullet.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * bulletVelocity;

                StartCoroutine("CO_AutoFire");
            }

            else if (isShotgun)
            {
                for (int i = 0; i < pelletCount; i++)
                {
                    bullet = Instantiate(bulletPrefab, playerPosition, playerRotation);
                    bullet.transform.Rotate(0, 0, Random.Range(-shotgunSpread, shotgunSpread));
                    bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * (bulletVelocity * Random.Range(0.8f,1f));
                }
            }

            gunAmmo.RemoveAmmoFromClip();
            Debug.Log("Gun Fired. " + gunAmmo.GetCurrentClipCapacity() + " remaining in Clip. " + gunAmmo.GetCurrentAmmoReserve() + " Remaining in Reserves.");

            if (gunAmmo.isClipEmpty())
            {
                Debug.Log("Gun Empty!");
                player.GetComponent<PlayerController>().Reload();
            }
        }
    }

    public void Reload()
    {
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
        if (isRifle && isAutoActive)
        {
            Fire();
        }
    }
}
