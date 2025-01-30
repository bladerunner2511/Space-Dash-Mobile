using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject highScorePanel;
    private HighScoreUI highScoreUI;
    private ScreenFader screenFader;

    private void Start()
    {
        settingsPanel.SetActive(false);
        highScorePanel.SetActive(false);

        highScoreUI = highScorePanel.GetComponent<HighScoreUI>();
        screenFader = FindObjectOfType<ScreenFader>(); // Find the fader in the scene
    }

    public void PlayGame()
    {
        if (screenFader != null)
        {
            screenFader.FadeToGameScene("Game"); // Replace with your game scene name
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
    }

    public void OpenHighScore()
    {
        highScorePanel.SetActive(true);
        highScoreUI.UpdateHighScore();
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
