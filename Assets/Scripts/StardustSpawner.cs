using UnityEngine;

public class StardustSpawner : MonoBehaviour
{
    public Transform player;
    public float spawnRate = 2.5f;
    public float spawnDistance = 40f;
    public float horizontalSpacing = 3f;
    public float StardustSpacing = 2f;
    public int minStardustsInRow = 3;
    public int maxStardustsInRow = 7;

    private float nextSpawnTime = 0f;

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnStardustRow();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnStardustRow()
    {
        int numberOfStardusts = Random.Range(minStardustsInRow, maxStardustsInRow + 1);

        float[] lanes = new float[] { -horizontalSpacing, 0f, horizontalSpacing };
        float laneX = lanes[Random.Range(0, lanes.Length)];
        Vector3 spawnPosition = new Vector3(laneX, player.position.y, player.position.z + spawnDistance);

        // Spawn Stardusts using object pooling
        for (int i = 0; i < numberOfStardusts; i++)
        {
            Vector3 StardustPosition = spawnPosition + new Vector3(0, 0, i * StardustSpacing);
            StardustPool.Instance.GetFromPool(StardustPosition);
        }
    }
}
