using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    public GameObject gameOverScreen; // Verwijzing naar het Game Over-scherm UI

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Controleer of de speler de doodszone is binnengekomen
        if (collision.CompareTag("Player"))
        {
            // Toon het Game Over-scherm
            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true);
            }

            // Optioneel: Zet de besturing van de speler uit
            collision.gameObject.SetActive(false); // Zet de speler uit voor eenvoud
        }
    }

    // Optioneel: Herstart het level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Herlaad het huidige level
    }
}
