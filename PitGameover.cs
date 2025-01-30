using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    public GameObject gameOverScreen; // Reference to the Game Over screen UI

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player entered the death zone
        if (collision.CompareTag("Player"))
        {
            // Show the Game Over screen
            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true);
            }

            // Optionally disable player controls
            collision.gameObject.SetActive(false); // Disable player for simplicity
        }
    }

    // Optional: Restart the level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
