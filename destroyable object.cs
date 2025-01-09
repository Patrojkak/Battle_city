using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public string targetTag = "Destroyable"; // Set this to the tag you want to check for
    public int points = 10; // Points to add when destroyed

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            // Add points to the score
            GameManager.Instance.AddScore(points);
            // Destroy the object
            Destroy(other.gameObject);
        }
    }
}