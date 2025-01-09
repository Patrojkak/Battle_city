using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab to spawn
    public Transform spawnPoint; // The point from which to spawn the objects
    public int maxObjects = 3; // Maximum number of objects allowed
    public float spawnInterval = 2f; // Time interval between spawn checks

    private void Start()
    {
        // Start the spawn check coroutine
        StartCoroutine(SpawnObjects());
    }

    private System.Collections.IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Count the number of active objects with the specified tag
            int currentObjectCount = GameObject.FindGameObjectsWithTag(objectToSpawn.tag).Length;

            // If the count is less than the maximum, spawn new objects
            while (currentObjectCount < maxObjects)
            {
                SpawnObject();
                currentObjectCount++;
            }

            // Wait for the specified interval before checking again
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnObject()
    {
        // Instantiate the object at the spawn point's position
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
