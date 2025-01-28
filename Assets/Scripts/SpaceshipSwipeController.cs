using UnityEngine;

public class SpaceshipSwipeController : MonoBehaviour
{
    public float speed = 10f;                // Forward movement speed
    public float swipeDistance = 2f;        // Distance the spaceship moves per swipe
    public float horizontalBoundary = 5f;   // Horizontal movement boundary
    public float verticalBoundary = 3f;     // Vertical movement boundary
    public float tiltAngle = 15f;           // Maximum tilt angle for rotation
    public float rotationSpeed = 5f;        // Speed of rotation smoothing

    private Vector2 startTouchPosition, swipeDelta; // Variables to track swipe input
    private bool isSwiping = false;
    private Vector3 targetPosition;         // Position the spaceship moves toward
    private Quaternion targetRotation;      // Rotation during movement
    private Quaternion neutralRotation;     // Neutral (level) rotation

    private void Start()
    {
        // Set the initial target position and neutral rotation
        targetPosition = transform.position;
        neutralRotation = Quaternion.identity; // Default rotation (level)
        targetRotation = neutralRotation;      // Start with the neutral rotation
    }

    private void Update()
    {
        DetectSwipe(); // Check for swipe gestures

        // Move the spaceship forward automatically
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Smoothly move the spaceship toward the target position for side/up/down movement
        transform.position = Vector3.Lerp(
            new Vector3(transform.position.x, transform.position.y, transform.position.z),
            new Vector3(targetPosition.x, targetPosition.y, transform.position.z),
            Time.deltaTime * 10f
        );

        // Check if the spaceship has reached the target position
        if (Vector3.Distance(new Vector3(transform.position.x, transform.position.y),
            new Vector3(targetPosition.x, targetPosition.y)) < 0.1f)
        {
            // If at the target position, return to level rotation
            targetRotation = neutralRotation;
        }

        // Smoothly rotate the spaceship to the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void DetectSwipe()
    {
        // Check if there is at least one touch on the screen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            if (touch.phase == TouchPhase.Began)
            {
                // Start tracking the swipe
                isSwiping = true;
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved && isSwiping)
            {
                // Calculate the swipe delta
                swipeDelta = touch.position - startTouchPosition;

                // Check if the swipe is significant enough
                if (swipeDelta.magnitude > 50)
                {
                    // Determine the swipe direction
                    if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                    {
                        // Horizontal swipe
                        if (swipeDelta.x > 0)
                            MoveRight();
                        else
                            MoveLeft();
                    }
                    else
                    {
                        // Vertical swipe
                        if (swipeDelta.y > 0)
                            MoveUp();
                        else
                            MoveDown();
                    }

                    // Reset swipe tracking
                    isSwiping = false;
                }
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // Reset swipe tracking when touch ends
                isSwiping = false;
                swipeDelta = Vector2.zero;
            }
        }
    }

    private void MoveUp()
    {
        // Move the spaceship upward, within the vertical boundary
        targetPosition += Vector3.up * swipeDistance;
        targetPosition.y = Mathf.Clamp(targetPosition.y, 1f, verticalBoundary);

        // Adjust rotation for upward tilt
        targetRotation = Quaternion.Euler(-tiltAngle, 0, 0); // Tilt forward (pitch up)
    }

    private void MoveDown()
    {
        // Move the spaceship downward, within the vertical boundary
        targetPosition += Vector3.down * swipeDistance;
        targetPosition.y = Mathf.Clamp(targetPosition.y, 1f, verticalBoundary);

        // Adjust rotation for downward tilt
        targetRotation = Quaternion.Euler(tiltAngle, 0, 0); // Tilt backward (pitch down)
    }

    private void MoveLeft()
    {
        // Move the spaceship to the left, within the horizontal boundary
        targetPosition += Vector3.left * swipeDistance;
        targetPosition.x = Mathf.Clamp(targetPosition.x, -horizontalBoundary, horizontalBoundary);

        // Adjust rotation for left tilt
        targetRotation = Quaternion.Euler(0, 0, tiltAngle); // Tilt left (roll)
    }

    private void MoveRight()
    {
        // Move the spaceship to the right, within the horizontal boundary
        targetPosition += Vector3.right * swipeDistance;
        targetPosition.x = Mathf.Clamp(targetPosition.x, -horizontalBoundary, horizontalBoundary);

        // Adjust rotation for right tilt
        targetRotation = Quaternion.Euler(0, 0, -tiltAngle); // Tilt right (roll)
    }
}
