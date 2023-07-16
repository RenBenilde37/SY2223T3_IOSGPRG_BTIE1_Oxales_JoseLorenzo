using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public string gunType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            PlayerInventory player = collision.GetComponent<PlayerInventory>();
            player.SwapWeapon(gunType);

            Destroy(gameObject);
        }
    }
}
