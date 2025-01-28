using UnityEngine;

public class AsteroidMover : MonoBehaviour
{
    public float speed = 10f; // Speed of the asteroid's movement

    private void Update()
    {
        // Move the asteroid globally in the negative Z direction (toward the player)
        transform.position += Vector3.back * speed * Time.deltaTime;

        // Optional: Destroy the asteroid if it moves past the player's position
        if (transform.position.z < Camera.main.transform.position.z - 10f)
        {
            Destroy(gameObject);
        }
    }
}
