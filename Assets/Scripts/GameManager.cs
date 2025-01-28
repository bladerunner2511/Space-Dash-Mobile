using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GameOver()
    {
        Debug.Log("Game Over!");
        // Add functionality to handle Game Over (e.g., showing a Game Over screen)

        // Return to main menu after a delay
        Invoke("LoadMainMenu", 2f); // 2-second delay
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
