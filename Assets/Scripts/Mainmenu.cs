using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("Game");
    }

    public void ShowHighscore()
    {
        Debug.Log("Highscore button clicked!");
        // Add functionality to show high scores
    }

    public void OpenSettings()
    {
        Debug.Log("Settings button clicked!");
        // Add functionality to open settings
    }

    public void ExitGame()
    {
        Debug.Log("Exit button clicked!");
        Application.Quit(); // Quit the application (only works in a built game)
    }
}
