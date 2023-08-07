using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    //[SerializeField] private GameObject player;

    public bool is9mm;
    public bool is556mm;
    public bool is12ga;


    public Gun.WeaponType WeaponType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string playerName = collision.gameObject.name;

        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerInventory player = collision.gameObject.GetComponent<PlayerInventory>();

            if (WeaponType == Gun.WeaponType.Pistol) { 
                Debug.Log("Touched " + playerName);
                player.ammoPistol.AddClip();
            }

            if (WeaponType == Gun.WeaponType.Rifle)
            {
                Debug.Log("Touched " + playerName);
                player.ammoRifle.AddClip();
            }

            if (WeaponType == Gun.WeaponType.Shotgun)
            {
                Debug.Log("Touched " + playerName);
                player.ammoShotgun.AddClip();
            }
            Destroy(gameObject);
        }
    }
}
