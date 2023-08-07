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

    [SerializeField] public Image healthBarSprite;

    [SerializeField] public PlayerInventory inventory;

    private void Update()
    {
        if (inventory.EquippedGun)
            UpdateAmmo();
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        healthBarSprite.fillAmount = currentHealth / maxHealth;
    }

    public void UpdateAmmo()
    {

        Ammo gunAmmo = inventory.EquippedGun.GetComponent<Gun>().gunAmmo;

        pistolAmmo.text = inventory.ammoPistol.GetCurrentAmmoReserve().ToString();
        rifleAmmo.text = inventory.ammoRifle.GetCurrentAmmoReserve().ToString();
        shotgunAmmo.text = inventory.ammoShotgun.GetCurrentAmmoReserve().ToString();

        clip.text = gunAmmo.GetCurrentClipCapacity().ToString();
        reserves.text = gunAmmo.GetCurrentAmmoReserve().ToString();
    }
}
