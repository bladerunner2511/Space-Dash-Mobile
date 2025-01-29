using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Different obstacles to spawn
    public Transform player;
    public float spawnRate = 3f; // Time between obstacle spawns
    public float horizontalRange = 4f; // How wide the obstacles can spawn
    public float spawnDistance = 30f; // Distance ahead of the player

    private float nextSpawnTime = 0f;

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnObstacle()
    {
        // Safety check: Ensure there are obstacle prefabs assigned
        if (obstaclePrefabs.Length == 0)
        {
            Debug.LogWarning("No obstacle prefabs assigned to ObstacleSpawner!");
            return;
        }

        Vector3 spawnPosition = new Vector3(
            Random.Range(-horizontalRange, horizontalRange), // Random X position
            1f, // Keep obstacles grounded (assuming platform height is at Y = 0)
            player.position.z + spawnDistance
        );

        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }
}
