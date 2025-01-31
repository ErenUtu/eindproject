using UnityEngine;

public class MovingPlatformLeftRight : MonoBehaviour
{
    public float moveSpeed = 2f; // Snelheid van het platform
    public float moveRange = 3f; // Hoe ver het platform naar links en rechts beweegt
    private Vector3 startPos; // De beginpositie van het platform

    void Start()
    {
        startPos = transform.position; // Sla de beginpositie op
    }

    void Update()
    {
        MovePlatform(); // Beweeg het platform elke frame
    }

    void MovePlatform()
    {
        // Beweeg het platform naar links en rechts met behulp van Mathf.PingPong
        transform.position = new Vector3(startPos.x + Mathf.PingPong(Time.time * moveSpeed, moveRange), transform.position.y, transform.position.z);
    }
}
