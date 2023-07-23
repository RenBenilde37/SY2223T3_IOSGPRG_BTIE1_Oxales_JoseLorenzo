using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] public GameObject Rifle;
    [SerializeField] public GameObject Shotgun;
    [SerializeField] public GameObject Pistol;

    [SerializeField] public GameObject CurrentPrimary;
    [SerializeField] public GameObject EquippedGun;

    [SerializeField] public Ammo ammoPistol = new Ammo(15, 90);
    [SerializeField] public Ammo ammoRifle = new Ammo(30, 120);
    [SerializeField] public Ammo ammoShotgun = new Ammo(2, 60);

    public bool spawnWithRandomWeapon;

    bool isSecondaryActive;

    private void Start()
    {
        Rifle.SetActive(false);
        Shotgun.SetActive(false);
        Pistol.SetActive(false);

        isSecondaryActive = false;

        if (spawnWithRandomWeapon)
            RandomizeWeapon();
    }

    public void SwapWeapon(string gun)
    {
        //Pickup in World

        if (gun == "Rifle")
        {
            Rifle.SetActive(true);
            Shotgun.SetActive(false);
            Pistol.SetActive(false);

            ammoRifle.FillClip();

            EquippedGun = Rifle;
            CurrentPrimary = Rifle;
        }

        if (gun == "Shotgun")
        {
            Rifle.SetActive(false);
            Shotgun.SetActive(true);
            Pistol.SetActive(false);

            ammoShotgun.FillClip();
            EquippedGun = Shotgun;
            CurrentPrimary = Shotgun;
        }

        if (gun == "Pistol")
        {
            Rifle.SetActive(false);
            Shotgun.SetActive(false);
            Pistol.SetActive(true);

            ammoPistol.FillClip();
            EquippedGun = Pistol;
            isSecondaryActive = true;
        }
    }

    public void SwitchWeapon()
    {
        if(isSecondaryActive && EquippedGun == CurrentPrimary)
        {
            EquippedGun = Pistol;
            Pistol.SetActive(true);
            Rifle.SetActive(false);
            Shotgun.SetActive(false);
        }

        else if(EquippedGun == Pistol)
        {
            EquippedGun = CurrentPrimary;

            if(CurrentPrimary == Rifle)
            Rifle.SetActive(true);
            Pistol.SetActive(false);

            if (CurrentPrimary == Shotgun)
            Shotgun.SetActive(true);
            Pistol.SetActive(false);
        }
    }

    public void RandomizeWeapon()
    {
        int RandomGun = Random.Range(0, 3);
        switch (RandomGun)
        {
            case 0:
                SwapWeapon("Rifle");
                break;
            case 1:
                SwapWeapon("Shotgun");
                break;
            case 2:
                SwapWeapon("Pistol");
                break;
        }
    }
}
