using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle soundEffectsToggle;

    private void Start()
    {
        // Load saved settings
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        soundEffectsToggle.isOn = PlayerPrefs.GetInt("SoundEffects", 1) == 1;

        ApplySettings();
    }

    public void OnVolumeChanged(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();
    }

    public void OnSoundEffectsToggled(bool isEnabled)
    {
        PlayerPrefs.SetInt("SoundEffects", isEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void ApplySettings()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1f);
    }
}
