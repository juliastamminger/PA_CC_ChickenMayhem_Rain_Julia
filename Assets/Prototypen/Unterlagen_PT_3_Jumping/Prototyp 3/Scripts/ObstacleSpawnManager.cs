using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    // Prefab vom Hindernis
    public GameObject obstaclePrefab;

    // Position an der die Hindernisse erzeugt werden
    public Vector3 spawnPosition;

    // Zeit zwischen den Spawnvorgängen
    public float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnInterval, spawnInterval);
    }

    /// <summary>
    /// Neues Hindernis im Level erzeugens
    /// </summary>
    void SpawnObstacle() 
    {
        if (!JumpCharacterController.IsGameOver()) 
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }        
    }
}
