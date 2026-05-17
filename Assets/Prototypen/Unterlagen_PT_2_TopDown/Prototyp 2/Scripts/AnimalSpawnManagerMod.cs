using UnityEngine;

/// <summary>
/// SpawnManager für die Tiere und die PowerUps (MOD)
/// </summary>
public class AnimalSpawnManagerMod : MonoBehaviour
{
    // Array mit zur Verfügung stehenden Tiere
    public GameObject[] animals;

    public GameObject powerUp;

    // Bereichsangaben für Positionierung der Tiere
    public float xRange = 15;
    public float zRange = 20;

    // Zeitangaben für automatisches Erzeugen der Tiere
    public float startDelay = 2;
    public float spawnInterval = 1.5f;
    public float powerUpSpawnInterval = 5f;

    void Start()
    {
        InvokeRepeating("SpawnAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnPowerUp", startDelay, powerUpSpawnInterval);
    }


    // Tier in der Szene instanziieren
    void SpawnAnimal()
    {
        // Zufällige Position (x-Koordinate) erzeugen
        float randomXPosition = Random.Range(-xRange, xRange);
        // Zufälliges Tier aus dem Array auswählen
        int randomIndex = Random.Range(0, animals.Length);

        // Zufälliges Tier an zufälliger X-Position instanziieren
        Instantiate(animals[randomIndex], new Vector3(randomXPosition, 0, 20), animals[randomIndex].transform.rotation);
    }

    void SpawnPowerUp()
    {
        // Zufällige Position (x-Koordinate) erzeugen
        float randomXPosition = Random.Range(-xRange, xRange);
        
        // PowerUp an zufälliger X-Position instanziieren
        Instantiate(powerUp, new Vector3(randomXPosition, 0, 20), powerUp.transform.rotation);
    }
}
