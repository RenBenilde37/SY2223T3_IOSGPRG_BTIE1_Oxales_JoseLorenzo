using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] public GameObject Rifle;
    [SerializeField] public GameObject Shotgun;
    [SerializeField] public GameObject Pistol;

    GameObject CurrentPrimary;
    [SerializeField] public GameObject EquippedGun;

    [SerializeField] public Ammo ammoPistol = new Ammo(15, 90);
    [SerializeField] public Ammo ammoRifle = new Ammo(30, 120);
    [SerializeField] public Ammo ammoShotgun = new Ammo(2, 60);

    private void Start()
    {
        Rifle.SetActive(false);
        Shotgun.SetActive(false);
        Pistol.SetActive(false);
    }

    public void SwapWeapon(string gun)
    {
        //Pickup in World

        if (gun == "Rifle")
        {
            Rifle.SetActive(true);
            Shotgun.SetActive(false);
            Pistol.SetActive(false);

            CurrentPrimary = Rifle;
            ammoRifle.FillClip();
            EquippedGun = Rifle;
        }

        if (gun == "Shotgun")
        {
            Rifle.SetActive(false);
            Shotgun.SetActive(true);
            Pistol.SetActive(false);

            CurrentPrimary = Shotgun;
            ammoShotgun.FillClip();
            EquippedGun = Shotgun;
        }

        if (gun == "Pistol")
        {
            Rifle.SetActive(false);
            Shotgun.SetActive(false);
            Pistol.SetActive(true);

            ammoPistol.FillClip();
            EquippedGun = Pistol;
        }

    }

    public void SwitchWeapon()
    {
        //Swap Between Primary and Secondary NONFUNCTIONING
        if(EquippedGun.name != "Pistol")
        {
            EquippedGun = Pistol;
        }

        else if(CurrentPrimary)
        {
            EquippedGun = CurrentPrimary;
        }
    }
}
