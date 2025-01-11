using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject ObjectToSpawn; // The prefab to spawn
    public int MaxObjects = 3; // Maximum number of objects to spawn
    private List<GameObject> SpawnedObjects = new List<GameObject>(); // List to keep track of spawned objects

    void Start()
    {
        // Initial spawn
        for (int i = 0; i < MaxObjects; i++)
        {
            SpawnObjecT();
        }
    }

    void Update()
    {
        // Check for destroyed objects and spawn new ones if necessary
        for (int i = SpawnedObjects.Count - 1; i >= 0; i--)
        {
            if (SpawnedObjects[i] == null)
            {
                SpawnedObjects.RemoveAt(i);
                SpawnObjecT();
            }
        }
    }

    void SpawnObjecT()
    {
        if (SpawnedObjects.Count < MaxObjects)
        {
            GameObject newObject = Instantiate(ObjectToSpawn, GetRandomPosition(), Quaternion.identity);
            SpawnedObjects.Add(newObject);
        }
    }

    Vector3 GetRandomPosition()
    {
        // Generate a random position within a certain range
        float x = Random.Range(-5f, 5f);
        float y = 0.5f; // Adjust height as needed
        float z = Random.Range(-5f, 5f);
        return new Vector3(x, y, z);
    }
}
