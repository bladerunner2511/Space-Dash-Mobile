using UnityEngine;

public class SpaceshipCollision : MonoBehaviour
{
    public AudioClip StardustSound; // Sound when collecting a Stardust
    public AudioClip explosionSound; // Sound when hitting an asteroid
    public GameObject explosionEffect; // Explosion effect prefab
    public GameObject gameOverUI; // Reference to the Game Over UI panel

    private ScoreManager scoreManager;
    private bool isGameOver = false; // Ensures Game Over logic runs only once

    private void Start()
    {
        // Find ScoreManager in the scene
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("SpaceshipCollision: No ScoreManager found in the scene!");
        }

        // Hide Game Over UI at start
        gameOverUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isGameOver) return; // Prevent multiple triggers

        if (other.CompareTag("StarDust"))
        {
            // Play the Stardust collection sound
            AudioSource.PlayClipAtPoint(StardustSound, other.transform.position);

            // Return the Stardust to the object pool instead of destroying it
            StardustPool.Instance.ReturnToPool(other.gameObject);

            // Update the score
            if (scoreManager != null)
            {
                scoreManager.AddScore(1);
            }
        }
        else if (other.CompareTag("Obstacle")) // Collision with an asteroid
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true; // Prevents multiple calls

        // Play explosion sound
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);

        // Instantiate explosion effect
        if (explosionEffect)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Disable the spaceship (prevents further movement)
        gameObject.SetActive(false);

        // Update and save high score before showing the UI
        if (scoreManager != null)
        {
            scoreManager.CheckAndUpdateHighScore();
        }

        // Show Game Over UI with final score
        gameOverUI.SetActive(true);
        gameOverUI.GetComponent<GameOverUI>().ShowFinalScore(scoreManager.GetScore());

        // Stop time to freeze gameplay
        Time.timeScale = 0f;
    }
}
