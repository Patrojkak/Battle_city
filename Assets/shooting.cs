using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDlo : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign the prefab in the Inspector
    public float spawnDistance = 1.0f; // Distance to spawn from the origin
    public float speed = 5.0f; // Speed of the spawned object
    public float lifespan = 2.0f; // Time before the object despawns

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        // Instantiate the object at the current position + spawnDistance in the direction the player is looking
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position + transform.forward * spawnDistance, Quaternion.identity);

        // Start the movement and despawn coroutine
        StartCoroutine(MoveAndDestroy(spawnedObject));
    }

    private IEnumerator MoveAndDestroy(GameObject obj)
    {
        float elapsedTime = 0.0f;

        // Move the object in the direction the player is looking
        while (elapsedTime < lifespan)
        {
            obj.transform.position += transform.forward * speed * Time.deltaTime; // Move in the forward direction
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Destroy the object after the lifespan
        Destroy(obj);
    }
}