using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; // Reference to the asteroid prefab
    public Transform player;          // Reference to the player
    public float spawnRate = 2f;      // Time between spawns
    public float horizontalRange = 5f; // Horizontal spawn range
    public float verticalRange = 3f;   // Vertical spawn range
    public float spawnDistance = 30f;  // Distance in front of the player to spawn asteroids

    private float nextSpawnTime = 0f;

    private void Update()
    {
        // Check if it's time to spawn the next asteroid
        if (Time.time > nextSpawnTime)
        {
            SpawnAsteroid();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnAsteroid()
    {
        // Generate a random spawn position
        Vector3 spawnPosition = new Vector3(
            Random.Range(-horizontalRange, horizontalRange), // Random X position
            Random.Range(1f, verticalRange),                 // Random Y position
            player.position.z + spawnDistance                // Z position ahead of the player
        );

        // Instantiate the asteroid
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }
}
