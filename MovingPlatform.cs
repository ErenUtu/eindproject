using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Startpunt
    public Transform pointB; // Eindpunt
    public float speed = 2f; // Snelheid van het platform

    private Vector3 targetPosition; // Doelpositie van het platform

    void Start()
    {
        // Begin met bewegen richting punt B
        targetPosition = pointB.position;
    }

    void Update()
    {
        // Beweeg het platform richting de doelpositie
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Als het platform het doel heeft bereikt, verander het doel
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }
}
