using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyableObject : MonoBehaviour
{
    public string targetTag = "Destroyable"; 
    public int points = 10; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
           
            GameManager.Instance.AddScore(points);
            
            Destroy(other.gameObject);
          
            Destroy(gameObject);
        }
    }
}
