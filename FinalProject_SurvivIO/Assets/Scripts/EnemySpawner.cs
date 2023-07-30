using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemy;
    [SerializeField] public Transform[] spawnPoints;
    //public GameObject
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int random = Random.Range(0, 100);

            if (random < 50)
            {
                Instantiate(enemy, spawnPoints[i]);
            }
        }
    }
}
