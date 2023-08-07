using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject[] ammoPickup;
    [SerializeField] public GameObject[] weaponPickup;
    [SerializeField] public Transform[] spawnPoints;
    //public GameObject
    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int random = Random.Range(0, 100);

            if (random < 70)
            {
                int ammoElement = Random.Range(0, ammoPickup.Length);
                Instantiate(ammoPickup[ammoElement], spawnPoints[i]);
            }

            else if (random >= 30)
            {
                int weaponElement = Random.Range(0, weaponPickup.Length);
                Instantiate(weaponPickup[weaponElement], spawnPoints[i]);
            }
        }
    }
}
