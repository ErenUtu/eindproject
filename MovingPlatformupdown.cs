using UnityEngine;

public class MovingPlatformupdown : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the platform moves
    public float moveRange = 3f; // How far the platform will move up and down
    private Vector3 startPos;
    private bool movingUp = true;

    void Start()
    {
        startPos = transform.position; // Save the initial position of the platform
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        float moveDirection = movingUp ? 1 : -1; // If moving up, moveDirection is 1, else -1

        // Move the platform up and down
        transform.position = new Vector3(transform.position.x, startPos.y + Mathf.PingPong(Time.time * moveSpeed, moveRange), transform.position.z);

        // If platform reaches the max height or min height, change direction
        if (Mathf.Abs(transform.position.y - startPos.y) >= moveRange)
        {
            movingUp = !movingUp; // Reverse direction
        }
    }
}
