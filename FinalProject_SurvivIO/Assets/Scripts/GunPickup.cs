using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public Gun.WeaponType weaponType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            PlayerInventory player = collision.GetComponent<PlayerInventory>();
            player.SwapWeapon(weaponType);

            if (weaponType == Gun.WeaponType.Pistol)
                player.ammoPistol.FillClip();

            if (weaponType == Gun.WeaponType.Rifle)
                player.ammoRifle.FillClip();

            if (weaponType == Gun.WeaponType.Shotgun)
                player.ammoShotgun.FillClip();

            Destroy(gameObject);
        }
    }
}
