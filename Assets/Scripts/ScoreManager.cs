using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UI Text for current score
    private int score = 0;
    private int highScore = 0;

    private void Start()
    {
        // Load the saved high score when the game starts
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    // Returns the player's current session score
    public int GetScore()
    {
        return score;
    }

    // Returns the saved high score
    public int GetHighScore()
    {
        return highScore;
    }

    // Checks if the current score is a new high score and saves it
    public void CheckAndUpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); // Save new high score
            PlayerPrefs.Save(); // Ensure it's written to storage
        }
    }
}
