using UnityEngine;

public class AsteroidFadeIn : MonoBehaviour
{
    public float fadeDuration = 1.5f; // Time it takes to fade in
    private Renderer asteroidRenderer;
    private Material asteroidMaterial;
    private Color startColor;
    private float fadeTimer = 0f;

    private void Start()
    {
        // Try to find the Renderer on this GameObject first
        asteroidRenderer = GetComponent<Renderer>();

        // If no renderer is found, check child objects
        if (asteroidRenderer == null)
        {
            asteroidRenderer = GetComponentInChildren<Renderer>();
        }

        //  Still no renderer? Log an error and return
        if (asteroidRenderer == null)
        {
            Debug.LogError($"AsteroidFadeIn: No Renderer found on {gameObject.name} or its children!");
            return;
        }

        //  Get the material from the renderer
        asteroidMaterial = asteroidRenderer.material;

        // Ensure we have a material before modifying it
        if (asteroidMaterial == null)
        {
            Debug.LogError($"AsteroidFadeIn: No Material found on {gameObject.name}!");
            return;
        }

        // Set initial transparency to 0 (fully invisible)
        startColor = asteroidMaterial.color;
        asteroidMaterial.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }

    private void Update()
    {
        if (asteroidMaterial == null) return; // Safety check

        if (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, startColor.a, fadeTimer / fadeDuration);
            asteroidMaterial.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
        }
    }
}
