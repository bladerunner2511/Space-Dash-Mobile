using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage; // Assign the FadePanel image in Inspector
    public float fadeDuration = 0.5f; // Duration of fade

    private void Start()
    {
        fadeImage.gameObject.SetActive(true); // Ensure it's active for fade-in
        StartCoroutine(FadeIn());
    }

    public void FadeToGameScene(string sceneName)
    {
        fadeImage.gameObject.SetActive(true); // Enable before fade-out
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
        fadeImage.gameObject.SetActive(false); // Disable after fading in
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Stop game music when returning to the Main Menu
        if (sceneName == "MainMenu")
        {
            GameObject gameMusic = GameObject.Find("GameMusic");
            if (gameMusic != null)
            {
                Destroy(gameMusic);
            }
        }

        SceneManager.LoadScene(sceneName);
    }



}
