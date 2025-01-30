using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Starting point
    public Transform pointB; // Ending point
    public float speed = 2f; // Speed of the platform

    private Vector3 targetPosition;

    void Start()
    {
        // Start by moving towards point A
        targetPosition = pointB.position;
    }

    void Update()
    {
        // Move the platform towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // If the platform reaches the target, switch the target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }
}
