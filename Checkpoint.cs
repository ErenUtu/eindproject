using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public Text checkpointText;  // Reference to the UI Text component for displaying messages
    private bool isCheckpointSet = false; // To prevent resetting the checkpoint multiple times

    private void Start()
    {
        if (checkpointText != null)
        {
            checkpointText.text = ""; // Ensure the text is empty initially
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCheckpointSet) // Check if the player has entered the checkpoint
        {
            SetCheckpoint();
        }
    }

    private void SetCheckpoint()
    {
        isCheckpointSet = true; // Set the checkpoint

        // Display the "Checkpoint Set" message
        if (checkpointText != null)
        {
            checkpointText.text = "Checkpoint Set!";
        }

        // Optionally, you can save the player's position or other data here.
        // For example, you can store the position to respawn at this checkpoint later.
    }
}
