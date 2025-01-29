using UnityEngine;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; // Reference to the platform segment prefab
    public Transform player; // Reference to the player
    public int numberOfPlatforms = 5; // Number of platforms to keep in view
    public float platformLength = 30f; // Length of each platform segment

    private List<GameObject> activePlatforms = new List<GameObject>(); // Store spawned platforms
    private float nextSpawnZ = 0f; // Z position for spawning next platform

    private void Start()
    {
        // Spawn initial platforms
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    private void Update()
    {
        // Check if the player has moved past a platform segment
        if (player.position.z - 40 > nextSpawnZ - (numberOfPlatforms * platformLength))
        {
            SpawnPlatform(); // Spawn new platform
            RemoveOldPlatform(); // Remove the oldest one
        }
    }

    private void SpawnPlatform()
    {
        // Create a new platform at the next position
        GameObject newPlatform = Instantiate(platformPrefab, Vector3.forward * nextSpawnZ, Quaternion.identity);
        activePlatforms.Add(newPlatform); // Add to list
        nextSpawnZ += platformLength; // Move the spawn position forward
    }

    private void RemoveOldPlatform()
    {
        // Destroy the oldest platform and remove it from the list
        if (activePlatforms.Count > numberOfPlatforms)
        {
            Destroy(activePlatforms[0]);
            activePlatforms.RemoveAt(0);
        }
    }
}
