using UnityEngine;

public class AsteroidRotator : MonoBehaviour
{
    public float rotationSpeed = 50f;

    private void Update()
    {
        // Rotate the asteroid randomly
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
