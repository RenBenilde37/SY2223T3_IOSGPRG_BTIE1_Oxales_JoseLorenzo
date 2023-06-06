using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    public float spawnFrequency;

    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private Transform spawnedParent;
    [SerializeField] private List<GameObject> enemies;

    [SerializeField] private Transform playerTransform;

    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(1);
        StartCoroutine(CO_SpawnEnemy(spawnFrequency));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    private void SpawnEnemies(int count)
    {
        int random = Random.Range(0, enemyPrefab.Length);
        spawnPoint = playerTransform.position + new Vector3(0, 10, 0);
        GameObject enemy = Instantiate(enemyPrefab[random], spawnPoint, Quaternion.identity);

        enemy.transform.parent = spawnedParent;

        enemies.Add(enemy);
    }
    IEnumerator CO_SpawnEnemy(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            SpawnEnemies(1);
        }
    }
}