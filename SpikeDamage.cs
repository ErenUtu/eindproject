using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.name); // Debugging log

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit the spikes!"); // Log specific to the player
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        Debug.Log("Activating Game Over screen..."); // Debugging log
        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();

        if (gameOverManager != null)
        {
            gameOverManager.GameOver(); // Roep de Game Over methode aan.
        }
        else
        {
            Debug.LogError("GameOverManager not found in the scene!"); // Log error als de manager niet is gevonden.
        }
    }
}
