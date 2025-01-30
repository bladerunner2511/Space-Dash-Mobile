using UnityEngine;

public class SpaceshipCollision : MonoBehaviour
{
    public AudioClip StardustSound; // Stardust collection sound
    public AudioClip explosionSound; // Explosion sound
    public GameObject explosionEffect;
    public GameObject gameOverUI;
    private ScoreManager scoreManager;
    private bool isGameOver = false;
    private AudioSource audioSource; // Dedicated audio source for sounds

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("SpaceshipCollision: No ScoreManager found in the scene!");
        }

        gameOverUI.SetActive(false);

        // Add an AudioSource component for sound playback
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 1.0f; // Adjust volume as needed (1.0 = max)
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isGameOver) return;

        if (other.CompareTag("StarDust"))
        {
            PlayStardustSound(); // Use custom function for loudness control
            StardustPool.Instance.ReturnToPool(other.gameObject);
            scoreManager?.AddScore(1);
        }
        else if (other.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    private void PlayStardustSound()
    {
        if (StardustSound != null)
        {
            audioSource.PlayOneShot(StardustSound, 1.5f); // Increase volume (1.5x)
        }
    }

    private void GameOver()
    {
        isGameOver = true;

        AudioSource.PlayClipAtPoint(explosionSound, transform.position);

        if (explosionEffect)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        gameObject.SetActive(false);

        // Stop game music when Game Over UI appears
        StopGameMusic();

        // Update and save high score before showing UI
        if (scoreManager != null)
        {
            scoreManager.CheckAndUpdateHighScore();
        }

        // Show Game Over UI with final score
        gameOverUI.SetActive(true);
        gameOverUI.GetComponent<GameOverUI>().ShowFinalScore(scoreManager.GetScore());

        Time.timeScale = 0f; // Stop gameplay
    }

    private void StopGameMusic()
    {
        GameObject gameMusic = GameObject.Find("GameMusic");
        if (gameMusic != null)
        {
            Destroy(gameMusic);
        }
    }
}
