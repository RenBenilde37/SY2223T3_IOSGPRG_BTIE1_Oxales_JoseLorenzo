using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo //MonoBehaviour
{
    int ammoMaxCapacity;
    int clipCapacity;

    int currentClipCapacity;
    int currentAmmoReserve;

    public Ammo(int clipCapacity, int ammoMaxCapacity)
    {
        this.clipCapacity = clipCapacity;
        this.ammoMaxCapacity = ammoMaxCapacity;
    }

    public void AddClip()
    {
        if(currentAmmoReserve != ammoMaxCapacity)
        {
            currentAmmoReserve += clipCapacity;

            if (currentAmmoReserve > ammoMaxCapacity)
                currentAmmoReserve = ammoMaxCapacity;

            Debug.Log("Ammo Picked Up");
        }
    }

    public void RemoveAmmoFromClip(int amount)
    {
        if (currentClipCapacity > 0)
        {
            currentClipCapacity -= amount;
        }
    }

    public void Reload(int ammoLoaded)
    {
        if (currentClipCapacity < clipCapacity)
        {
            currentAmmoReserve -= (clipCapacity - currentClipCapacity);
            currentClipCapacity = clipCapacity;
        }
    }
}
