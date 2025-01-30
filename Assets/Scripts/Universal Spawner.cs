using UnityEngine;

public class UniversalSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs; // Different asteroid variants
    public Transform player;
    public float spawnRate = 2f; // Time between spawns
    public float horizontalRange = 5f; // How wide objects can spawn
    public float verticalMin = 3f; // Minimum height for asteroids
    public float verticalMax = 8f; // Maximum height for asteroids
    public float spawnDistance = 30f; // Distance ahead of the player

    private float nextSpawnTime = 0f;

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnObject(); // Spawns either an asteroid or an obstacle
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnObject()
    {
        // Decide randomly whether to spawn an asteroid or an obstacle
        bool spawnAsteroid = Random.value < 0.5f; // 50% chance for asteroid

        if (spawnAsteroid)
        {
            SpawnAsteroid();
        }
      
    }

    private void SpawnAsteroid()
    {
        if (asteroidPrefabs.Length == 0)
        {
            Debug.LogWarning("No asteroid prefabs assigned to UniversalSpawner!");
            return;
        }

        Vector3 spawnPosition = new Vector3(
            Random.Range(-horizontalRange, horizontalRange), // Random X
            Random.Range(verticalMin, verticalMax), // Random Y (floating)
            player.position.z + spawnDistance // Z (ahead of player)
        );

        int randomIndex = Random.Range(0, asteroidPrefabs.Length);
        GameObject asteroid = Instantiate(asteroidPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        asteroid.AddComponent<AsteroidFadeIn>(); // Attach fade-in script

    }

}