using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public Transform shootingPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);

        // Get the direction to shoot the projectile
        Vector2 direction = shootingPoint.transform.up;

        // Set the projectile's rotation to face the opposite direction
        projectile.transform.rotation = Quaternion.LookRotation(Vector3.forward, -direction);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Apply velocity in the opposite direction
            rb.velocity = -direction * projectileSpeed; // Use the negative direction for opposite
        }

        // Destroy the projectile after 5 seconds
        Destroy(projectile, 5f);
    }
}