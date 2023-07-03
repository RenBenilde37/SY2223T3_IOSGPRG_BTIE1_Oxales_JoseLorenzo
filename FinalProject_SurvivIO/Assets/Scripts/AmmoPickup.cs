using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public string ammoType;
    //[SerializeField] private GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (ammoType == "pistol")
            {
                Debug.Log("Touched " + collision.gameObject.name);
                collision.gameObject.GetComponent<PlayerController>().ammoPistol.AddClip();
            }

            else if (ammoType == "rifle")
            {
                Debug.Log("Touched " + collision.gameObject.name);
                collision.gameObject.GetComponent<PlayerController>().ammoRifle.AddClip();
            }

            else if (ammoType == "shotgun")
            {
                Debug.Log("Touched " + collision.gameObject.name);
                collision.gameObject.GetComponent<PlayerController>().ammoShotgun.AddClip();
            }

            Destroy(gameObject);
        }
    }
}
