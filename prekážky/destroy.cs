using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    
    
        print(collision.gameObject.tag);
        print(transform.gameObject);
        if (collision.gameObject.CompareTag("naboj"))
        {
            Destroy(transform.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("neznic"))
        {
            Destroy(transform.gameObject);
        }
    
    
    
    
    
    }



}
