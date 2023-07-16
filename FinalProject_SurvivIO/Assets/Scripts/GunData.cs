using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunData : MonoBehaviour
{
    [SerializeField] string gunName;

    [SerializeField] bool isAutomatic;
    [SerializeField] bool isShotgun;

    [SerializeField] float damage;

    public float fireRate;
    public bool isReloading;
    public float reloadTime;
}
