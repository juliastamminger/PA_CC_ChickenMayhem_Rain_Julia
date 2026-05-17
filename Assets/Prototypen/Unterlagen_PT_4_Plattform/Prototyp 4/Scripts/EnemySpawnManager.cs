using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    // Prefab des Gegners
    public GameObject enemyPrefab;
    // Prefab des Powerups
    public GameObject powerupPrefab;

    // Bereich in dem Gegner/Powerups erzeugt werden
    public float spawnRange;

    // In welcher Welle befinden wir uns
    private int waveCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveCount);
    }

    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveCount++;
            SpawnEnemyWave(waveCount);
        }
    }

    /// Erzeuge eine bestimmte Anzahl von Gegnern
    /// und zusätzlich ein Powerup
    private void SpawnEnemyWave(int enemiesToSpwan)
    {
        for (int i = 0; i < enemiesToSpwan; i++)
        {
             SpawnPrefab(enemyPrefab);
        }

        SpawnPrefab(powerupPrefab);
    }

    private void SpawnPrefab(GameObject prefabToSpawn)
    {
        Instantiate(prefabToSpawn, GenerateRandomPosition(), prefabToSpawn.transform.rotation);
    }    

    // Berechne eine Position in einem bestimmten Bereich
    private Vector3 GenerateRandomPosition()
    {
        Vector3 randowmPosition = new Vector3(  Random.Range(-spawnRange, spawnRange),
                                                0,
                                                Random.Range(-spawnRange, spawnRange));

        return randowmPosition;
    }
}
