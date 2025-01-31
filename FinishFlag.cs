using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlag : MonoBehaviour
{
    public GameObject finishScreen; // Verwijzing naar het Finish Screen UI

    private void Start()
    {
        // Verberg het Finish Screen bij het starten
        if (finishScreen != null)
        {
            finishScreen.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Controleer of de speler de vlag aanraakt
        {
            FinishLevel();
        }
    }

    void FinishLevel()
    {
        if (finishScreen != null)
        {
            finishScreen.SetActive(true); // Toon de finish screen UI
            Time.timeScale = 0f; // Pauzeer het spel
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Hervat de tijd (unpause het spel)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Herlaad de huidige scène
    }
}
