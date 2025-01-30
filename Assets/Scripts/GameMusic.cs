using UnityEngine;

public class GameMusic : MonoBehaviour
{
    private static GameMusic instance;

    private void Awake()
    {
        // Ensure only one instance of GameMusic exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps music playing across scene reloads
        }
        else
        {
            Destroy(gameObject); // Prevents duplicate music when restarting the game
        }

        // Stop Main Menu music if it's still playing
        GameObject menuMusic = GameObject.Find("MainMenuMusic");
        if (menuMusic != null)
        {
            Destroy(menuMusic);
        }
    }
}
