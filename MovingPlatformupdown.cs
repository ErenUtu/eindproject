using UnityEngine;

public class MovingPlatformupdown : MonoBehaviour
{
    public float moveSpeed = 2f; // Snelheid waarmee het platform beweegt
    public float moveRange = 3f; // Hoe ver het platform op en neer beweegt
    private Vector3 startPos; // De beginpositie van het platform
    private bool movingUp = true; // Bepaalt of het platform omhoog beweegt

    void Start()
    {
        startPos = transform.position; // Sla de beginpositie van het platform op
    }

    void Update()
    {
        MovePlatform(); // Beweeg het platform elke frame
    }

    void MovePlatform()
    {
        float moveDirection = movingUp ? 1 : -1; // Als het platform omhoog beweegt, is moveDirection 1, anders -1

        // Beweeg het platform op en neer
        transform.position = new Vector3(transform.position.x, startPos.y + Mathf.PingPong(Time.time * moveSpeed, moveRange), transform.position.z);

        // Als het platform de maximale of minimale hoogte bereikt, verander van richting
        if (Mathf.Abs(transform.position.y - startPos.y) >= moveRange)
        {
            movingUp = !movingUp; // Verander van richting
        }
    }
}
