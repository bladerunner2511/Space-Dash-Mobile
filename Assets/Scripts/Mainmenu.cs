using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel; // Reference to the Settings UI
    public GameObject highScorePanel; // Reference to the High Score UI

    private void Start()
    {
        // Ensure both panels are hidden at start
        settingsPanel.SetActive(false);
        highScorePanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game"); // Replace with your game scene name
    }

    public void OpenHighScore()
    {
        highScorePanel.SetActive(true);
    }

    public void CloseHighScore()
    {
        highScorePanel.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
