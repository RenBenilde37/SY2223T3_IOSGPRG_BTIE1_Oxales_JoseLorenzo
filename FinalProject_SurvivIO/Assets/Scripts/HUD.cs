using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HUD : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI clip;
    [SerializeField] public TextMeshProUGUI reserves;
    [SerializeField] public TextMeshProUGUI pistolAmmo;
    [SerializeField] public TextMeshProUGUI rifleAmmo;
    [SerializeField] public TextMeshProUGUI shotgunAmmo;

    [SerializeField] public PlayerInventory inventory;

    
    // Start is called before the first frame update
    void Start()
    {
        //UpdateAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAmmo()
    {
        Ammo gunAmmo = inventory.EquippedGun.GetComponent<Gun>().gunAmmo;

        clip.text = gunAmmo.GetCurrentClipCapacity().ToString();
        reserves.text = gunAmmo.GetCurrentAmmoReserve().ToString();

        pistolAmmo.text = inventory.ammoPistol.GetCurrentAmmoReserve().ToString();
        rifleAmmo.text = inventory.ammoRifle.GetCurrentAmmoReserve().ToString();
        shotgunAmmo.text = inventory.ammoShotgun.GetCurrentAmmoReserve().ToString();
    }
}
