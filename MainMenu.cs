using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start het spel door de eerste sc�ne te laden
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("1"); // Laad de sc�ne met de naam "1"
    }

    // Sluit de applicatie
    public void QuitGame()
    {
        Application.Quit(); // Verlaat de applicatie
    }
}
