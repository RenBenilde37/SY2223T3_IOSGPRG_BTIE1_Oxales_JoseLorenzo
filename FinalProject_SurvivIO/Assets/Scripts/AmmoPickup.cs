using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    //[SerializeField] private GameObject player;

    public bool is9mm;
    public bool is556mm;
    public bool is12ga;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string playerName = collision.gameObject.name;

        if (collision.gameObject.name == "Player")
        {
            PlayerInventory player = collision.gameObject.GetComponent<PlayerInventory>();

            if (is9mm) { 
                Debug.Log("Touched " + playerName);
                player.ammoPistol.AddClip();
            }

            if (is556mm)
            {
                Debug.Log("Touched " + playerName);
                player.ammoRifle.AddClip();
            }

            if (is12ga)
            {
                Debug.Log("Touched " + playerName);
                player.ammoShotgun.AddClip();
            }

            Destroy(gameObject);
        }
    }
}
