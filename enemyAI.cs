using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints; // List of waypoints
    public float speed = 2f; // Movement speed
    public float pauseDuration = 1f; // Pause time at each waypoint

    private int targetWaypointIndex = -1; // Target waypoint index
    private int previousWaypointIndex = -1; // Keep track of the last visited waypoint
    private Vector2 currentDirection; // Current movement direction
    private Rigidbody2D rb; // Rigidbody component
    private bool isPaused = false; // Pause state

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Initialize with the closest waypoint
        targetWaypointIndex = GetClosestWaypointIndex();
        UpdateDirection();
    }

    private void Update()
    {
        if (!isPaused)
        {
            Move();

            // Check if the enemy has reached the current waypoint
            if (Vector2.Distance(transform.position, waypoints[targetWaypointIndex].position) < 0.1f)
            {
                StartCoroutine(PauseAndSelectNextWaypoint());
            }
        }
    }

    private void Move()
    {
        rb.velocity = currentDirection * speed;
    }

    private IEnumerator PauseAndSelectNextWaypoint()
    {
        isPaused = true;
        rb.velocity = Vector2.zero; // Stop movement
        yield return new WaitForSeconds(pauseDuration);

        // Select the next waypoint to move toward
        previousWaypointIndex = targetWaypointIndex;
        targetWaypointIndex = GetNextWaypointIndex();
        UpdateDirection();

        isPaused = false;
    }

    private int GetClosestWaypointIndex()
    {
        float shortestDistance = float.MaxValue;
        int closestWaypointIndex = -1;

        Vector2 currentPosition = transform.position;

        for (int i = 0; i < waypoints.Length; i++)
        {
            float distance = Vector2.Distance(currentPosition, waypoints[i].position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestWaypointIndex = i;
            }
        }

        return closestWaypointIndex;
    }

    private int GetNextWaypointIndex()
    {
        float shortestTotalDistance = float.MaxValue;
        int bestWaypointIndex = -1;

        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = waypoints[targetWaypointIndex].position;

        for (int i = 0; i < waypoints.Length; i++)
        {
            if (i == previousWaypointIndex) continue; // Skip the last visited waypoint

            float distanceToWaypoint = Vector2.Distance(currentPosition, waypoints[i].position);
            float distanceFromWaypointToTarget = Vector2.Distance(waypoints[i].position, targetPosition);

            // Total distance = distance to waypoint + distance to target from waypoint
            float totalDistance = distanceToWaypoint + distanceFromWaypointToTarget;

            if (totalDistance < shortestTotalDistance)
            {
                shortestTotalDistance = totalDistance;
                bestWaypointIndex = i;
            }
        }

        return bestWaypointIndex != -1 ? bestWaypointIndex : Random.Range(0, waypoints.Length); // Fallback to random
    }

    private void UpdateDirection()
    {
        Vector2 targetPosition = waypoints[targetWaypointIndex].position;
        Vector2 direction = targetPosition - (Vector2)transform.position;

        // Restrict movement to horizontal or vertical
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            currentDirection = new Vector2(Mathf.Sign(direction.x), 0); // Horizontal
        }
        else
        {
            currentDirection = new Vector2(0, Mathf.Sign(direction.y)); // Vertical
        }

        Debug.Log($"Moving towards waypoint {targetWaypointIndex}, Direction: {currentDirection}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("stena"))
        {
            Debug.Log("Collided with a wall! Recalculating route.");

            // Force recalculation of the route
            targetWaypointIndex = GetClosestWaypointIndex();
            UpdateDirection();
        }
    }
}
