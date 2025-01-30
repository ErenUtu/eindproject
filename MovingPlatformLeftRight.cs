using UnityEngine;

public class MovingPlatformLeftRight : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of the platform
    public float moveRange = 3f; // How far it moves left and right
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // Store the initial position
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // Moves the platform left and right using Mathf.PingPong
        transform.position = new Vector3(startPos.x + Mathf.PingPong(Time.time * moveSpeed, moveRange), transform.position.y, transform.position.z);
    }
}
