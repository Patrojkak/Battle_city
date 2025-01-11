using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab to spawn
    public int maxObjects = 3; // Maximum number of objects to spawn
    public Vector3[] spawnPositions; // Array of spawn positions
    private List<GameObject> spawnedObjects = new List<GameObject>(); // List to keep track of spawned objects

    void Start()
    {
        // Initial spawn
        for (int i = 0; i < maxObjects; i++)
        {
            SpawnObject(i);
        }
    }

    void Update()
    {
        // Check for destroyed objects and spawn new ones if necessary
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            if (spawnedObjects[i] == null)
            {
                spawnedObjects.RemoveAt(i);
                SpawnObject(i); // Reuse the index for spawning
            }
        }
    }

    void SpawnObject(int index)
    {
        if (spawnedObjects.Count < maxObjects && index < spawnPositions.Length)
        {
            GameObject newObject = Instantiate(objectToSpawn, spawnPositions[index], Quaternion.identity);
            spawnedObjects.Add(newObject);
        }
    }
}
