using UnityEngine;
using TMPro; // Required for TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the UI text element
    private int score = 0;           // Current score

    private void Start()
    {
        // Initialize the score display
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        // Increment the score and update the UI
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        // Update the text element with the new score
        scoreText.text = "Score: " + score;
    }
}
