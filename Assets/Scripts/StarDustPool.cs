using UnityEngine;
using System.Collections.Generic;

public class StardustPool : MonoBehaviour
{
    public static StardustPool Instance { get; private set; }

    public GameObject StardustPrefab; // Assign the Stardust prefab in the Inspector
    public int poolSize = 20; // Number of Stardusts to keep in the pool

    private Queue<GameObject> StardustQueue = new Queue<GameObject>();

    private void Awake()
    {
        // Singleton pattern: Ensures there's only one instance of StardustPool
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Preload Stardusts into the pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject Stardust = Instantiate(StardustPrefab);
            Stardust.SetActive(false);
            StardustQueue.Enqueue(Stardust);
        }
    }

    public GameObject GetFromPool(Vector3 position)
    {
        if (StardustQueue.Count > 0)
        {
            GameObject Stardust = StardustQueue.Dequeue();
            Stardust.SetActive(true);
            Stardust.transform.position = position;
            return Stardust;
        }
        else
        {
            // Optional: Expand pool if needed
            GameObject newStardust = Instantiate(StardustPrefab, position, Quaternion.identity);
            return newStardust;
        }
    }

    public void ReturnToPool(GameObject Stardust)
    {
        Stardust.SetActive(false);
        StardustQueue.Enqueue(Stardust);
    }
}
