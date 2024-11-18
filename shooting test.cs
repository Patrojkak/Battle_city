using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public Transform shootingPoint;

    private bool canShoot = true; // Track if shooting is allowed

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Set canShoot to false as we are about to shoot
        canShoot = false;

        // Instantiate the projectile at the shooting point
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);

        // Set the direction to shoot the projectile
        Vector2 direction = shootingPoint.transform.up;

        // Adjust the projectile's rotation to match the direction
        projectile.transform.rotation = Quaternion.LookRotation(Vector3.forward, -direction);

        // Get the Rigidbody2D component and set the velocity
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = -direction * projectileSpeed;
        }

        // Destroy the projectile after a set amount of time (to avoid memory leaks)
        Destroy(projectile, 5f);  // Adjust this value as needed

        // Attach an event to the projectile's destruction
        StartCoroutine(WaitForProjectileDestruction(projectile));
    }

    private IEnumerator WaitForProjectileDestruction(GameObject projectile)
    {
        // Wait until the projectile is destroyed
        while (projectile != null)
        {
            yield return null;
        }

        // Allow shooting again once the projectile is destroyed
        canShoot = true;
    }
}