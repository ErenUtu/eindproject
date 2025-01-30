using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlag : MonoBehaviour
{
    public GameObject finishScreen; // Reference to the Finish Screen UI

    private void Start()
    {
        // Hide the Finish Screen at the start
        if (finishScreen != null)
        {
            finishScreen.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if player touches the flag
        {
            FinishLevel();
        }
    }

    void FinishLevel()
    {
        if (finishScreen != null)
        {
            finishScreen.SetActive(true); // Show the finish screen UI
            Time.timeScale = 0f; // Pause the game
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume time (unpause the game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
