using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI; // Sleep hier je Game Over UI-object in Unity.

    // Wordt automatisch aangeroepen bij het starten van het spel.
    void Start()
    {
        gameOverUI.SetActive(false); // Zorgt ervoor dat het scherm verborgen is bij de start van het spel.
    }

    // Roep deze methode aan wanneer de speler dood is.
    public void GameOver()
    {
        gameOverUI.SetActive(true); // Toont het Game Over scherm.
        Time.timeScale = 0f; // Pauzeert het spel.
    }

    // Methode om het spel opnieuw te starten.
    public void RestartGame()
    {
        Time.timeScale = 1f; // Zet de tijd weer aan.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Herstart de huidige scène.
    }

    // Methode om het spel te verlaten.
    public void QuitGame()
    {
        Application.Quit(); // Sluit het spel af.
        Debug.Log("Game closed!"); // Werkt alleen in een gebuild spel.
    }
}
