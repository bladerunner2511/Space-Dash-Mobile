using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    private static MainMenuMusic instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps music playing across scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicate music when returning to menu
        }
    }
}
