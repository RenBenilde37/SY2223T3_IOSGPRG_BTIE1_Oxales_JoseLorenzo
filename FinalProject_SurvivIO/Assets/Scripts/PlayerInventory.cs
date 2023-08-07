using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private HUD hud;
    [SerializeField] public GameObject[] weapons;

    [SerializeField] public GameObject CurrentPrimary;
    [SerializeField] public GameObject EquippedGun;

    [SerializeField] public Ammo ammoPistol = new Ammo(15, 90);
    [SerializeField] public Ammo ammoRifle = new Ammo(30, 120);
    [SerializeField] public Ammo ammoShotgun = new Ammo(2, 60);

    public bool spawnWithRandomWeapon;

    public bool isPlayer;

    private void Start()
    { 
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        if (spawnWithRandomWeapon)
            RandomizeWeapon();
    }

    public void SwapWeapon(Gun.WeaponType weaponType)
    {
        if (weaponType != Gun.WeaponType.Pistol)
            CurrentPrimary = weapons[((int)weaponType)];

        weapons[((int)weaponType)].SetActive(true);
        EquippedGun = weapons[((int)weaponType)];

        for (int i = 0; i < weapons.Length; i++)
        {
            if(i != ((int)weaponType))
                weapons[i].SetActive(false);
        }
    }

    public void SwitchWeapon()
    {
        Gun.WeaponType currentWeaponType = EquippedGun.GetComponent<Gun>().weaponType;

        EquippedGun.SetActive(false);

        if (currentWeaponType == CurrentPrimary.GetComponent<Gun>().weaponType)
        {
            EquippedGun = weapons[((int)Gun.WeaponType.Pistol)];
        }

        else if(EquippedGun.GetComponent<Gun>().weaponType == Gun.WeaponType.Pistol)
        {
            EquippedGun = CurrentPrimary;
        }

        EquippedGun.SetActive(true);

        Debug.Log("Switched To " + currentWeaponType.ToString());
    }

    public void RandomizeWeapon()
    {
        int RandomGun = Random.Range(0, 3);
        switch (RandomGun)
        {
            case 0:
                SwapWeapon(Gun.WeaponType.Pistol);
                break;
            case 1:
                SwapWeapon(Gun.WeaponType.Rifle);
                break;
            case 2:
                SwapWeapon(Gun.WeaponType.Shotgun);
                break;
        }
    }
}
