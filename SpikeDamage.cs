using UnityEngine;

public class Spike : MonoBehaviour
{
    // Reference to the GameOverScreen script
    public GameOverScreen gameOverScreen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player collided
        {
            // Optionally disable the player or trigger an animation
            other.gameObject.SetActive(false);

            // Trigger the game over screen
            if (gameOverScreen != null)
            {
                gameOverScreen.ShowGameOver();
            }
            else
            {
                Debug.LogError("GameOverScreen is not assigned to the spike!");
            }
        }
    }
}
