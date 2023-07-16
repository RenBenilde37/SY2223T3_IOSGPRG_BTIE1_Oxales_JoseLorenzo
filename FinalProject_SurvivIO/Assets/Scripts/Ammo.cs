using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo // MonoBehaviour
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
        if(currentAmmoReserve < ammoMaxCapacity)
        {
            currentAmmoReserve += clipCapacity;

            if (currentAmmoReserve > ammoMaxCapacity)
                currentAmmoReserve = ammoMaxCapacity;

            Debug.Log("Ammo Picked Up");
        }
    }

    public void RemoveAmmoFromClip()
    {
        if (currentClipCapacity > 0)
        {
            currentClipCapacity--;
        }
    }

    public void FillClip()
    {
        currentClipCapacity = clipCapacity;
    }

    public void Reload()
    {
        if (currentClipCapacity < clipCapacity && currentAmmoReserve > 0)
        {
            currentAmmoReserve += currentClipCapacity;

            if (currentAmmoReserve <= clipCapacity)
            {
                currentClipCapacity = currentAmmoReserve;
                currentAmmoReserve = 0;
            }

            else
            {
                currentClipCapacity = clipCapacity;
                currentAmmoReserve -= clipCapacity;
            }
        }
    }

    public bool isClipEmpty()
    {
        if (currentClipCapacity <= 0)
            return true;

        else
            return false;
    }

    public bool isTotallyEmpty()
    {
        if (currentClipCapacity <= 0 && currentAmmoReserve <= 0)
            return true;

        else
            return false;
    }


    public int GetCurrentClipCapacity()
    {
        return currentClipCapacity;
    }

    public int GetCurrentAmmoReserve()
    {
        return currentAmmoReserve;
    }
}
