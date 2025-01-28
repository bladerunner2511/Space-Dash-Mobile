using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Assign the player spaceship here
    public Vector3 offset;   // Offset from the player's position

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
