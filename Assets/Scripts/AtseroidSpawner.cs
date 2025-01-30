using UnityEngine;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs; // Different asteroid variants
    public Transform player;
    public float spawnRate = 2f; // Time between spawns
    public float horizontalRange = 5f; // How wide asteroids can spawn
    public float verticalMin = 3f; // Minimum height for asteroids
    public float verticalMax = 8f; // Maximum height
    public float spawnDistance = 30f; // Distance ahead of the player
    public float asteroidLifetime = 10f; // How long before asteroids are removed

    private float nextSpawnTime = 0f;
    private List<GameObject> activeAsteroids = new List<GameObject>(); // Store active asteroids

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnAsteroid();
            nextSpawnTime = Time.time + spawnRate;
        }

        // Remove old asteroids that have passed the player
        CleanupAsteroids();
    }

    private void SpawnAsteroid()
    {
        if (asteroidPrefabs.Length == 0)
        {
            Debug.LogWarning("No asteroid prefabs assigned to AsteroidSpawner!");
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

        activeAsteroids.Add(asteroid); // Track spawned asteroid

        // Destroy the asteroid after some time to avoid clutter
        Destroy(asteroid, asteroidLifetime);
    }

    private void CleanupAsteroids()
    {
        // Remove destroyed asteroids from the list
        activeAsteroids.RemoveAll(asteroid => asteroid == null);
    }

    public List<GameObject> GetActiveAsteroids()
    {
        return activeAsteroids;
    }
}
