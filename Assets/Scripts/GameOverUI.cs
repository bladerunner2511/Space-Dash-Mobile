using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private ScoreManager scoreManager;
    private ScreenFader screenFader;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        screenFader = FindObjectOfType<ScreenFader>(); // Find the Fade Manager


        if (scoreManager == null)
        {
            Debug.LogError("GameOverUI: No ScoreManager found in the scene!");
        }
    }

    public void ShowFinalScore(int finalScore)
    {
        scoreText.text = "Score: " + finalScore;

        // Get the high score and display it
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }

    public void RetryGame()
    {
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Resume time

        if (screenFader != null)
        {
            screenFader.FadeToGameScene("MainMenu"); // Fade transition to main menu 
        }

        else
        {
            SceneManager.LoadScene("MainMenu"); // Fallback to Main Menu if the ScreenFader is missing
        }
        
    }
}
