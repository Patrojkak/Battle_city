using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class l : MonoBehaviour
{
    public Transform bulletspawnpoint;
    public GameObject bulletPrefab;
    public float bulletspeed = 10;

    

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletspawnpoint.position, bulletspawnpoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletspawnpoint.up * bulletspeed;
        }
    }
    


}    
