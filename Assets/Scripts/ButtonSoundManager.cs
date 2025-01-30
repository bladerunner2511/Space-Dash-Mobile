using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundManager : MonoBehaviour
{
    public static ButtonSoundManager Instance;
    public AudioClip buttonClickSound;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonClickSound;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.7f;

        // Auto-assign sound to all buttons in the scene
        AssignButtonSounds();
    }

    private void AssignButtonSounds()
    {
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(PlayButtonClick);
        }
    }

    public void PlayButtonClick()
    {
        if (PlayerPrefs.GetInt("SoundEffects", 1) == 1) // Check if SFX is enabled
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
