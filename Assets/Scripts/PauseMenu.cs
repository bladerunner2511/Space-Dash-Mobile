using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the Pause Menu panel
    public Button pauseButton; // Pause Button reference
    public ScreenFader screenFader; // Reference to the fade effect
    private bool isPaused = false;
    private AudioSource gameMusic; // Reference to the game music audio source

    private void Start()
    {
        pauseMenuUI.SetActive(false); // Hide pause menu at start

        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(TogglePause); // Assign button event
        }

        // Find the GameMusic object and get its AudioSource
        GameObject musicObject = GameObject.Find("GameMusic");
        if (musicObject != null)
        {
            gameMusic = musicObject.GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        // Press "Escape" or "P" to toggle pause (for PC testing)
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuUI.SetActive(isPaused);

        // Pause or Resume the game
        Time.timeScale = isPaused ? 0f : 1f;

        // Hide pause button when paused
        if (pauseButton != null)
        {
            pauseButton.gameObject.SetActive(!isPaused);
        }

        // Pause/Resume game music
        if (gameMusic != null)
        {
            if (isPaused)
                gameMusic.Pause();
            else
                gameMusic.Play();
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        if (pauseButton != null)
        {
            pauseButton.gameObject.SetActive(true);
        }

        // Resume game music
        if (gameMusic != null)
        {
            gameMusic.Play();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;

        if (screenFader != null)
        {
            screenFader.FadeToGameScene("MainMenu"); // Use fade transition
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
