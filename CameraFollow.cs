using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset;   // Offset between the player and camera
    public float smoothSpeed = 0.125f; // Adjust for smoother movement

    void LateUpdate()
    {
        if (player != null)
        {
            // Target position based on the player's position and offset
            Vector3 targetPosition = player.position + offset;

            // Smoothly interpolate between the camera's current position and the target position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;
        }
    }
}
