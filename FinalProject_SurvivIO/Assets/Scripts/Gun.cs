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


            GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * bulletVelocity;

            //Uses AddForce()
            //bullet.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * bulletVelocity, ForceMode2D.Impulse);

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
}
