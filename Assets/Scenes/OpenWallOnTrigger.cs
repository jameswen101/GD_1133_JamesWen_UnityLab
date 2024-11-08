using UnityEngine;

public class OpenWallOnTrigger : MonoBehaviour
{
    public Transform wall;  // Reference to the wall transform
    public Vector3 openPosition;  // The target position when the wall opens
    public float openSpeed = 2f;  // Speed at which the wall opens

    private Vector3 initialPosition;  // The starting position of the wall
    private bool isOpening = false;  // Whether the wall should open

    void Start()
    {
        // Save the initial position of the wall
        if (wall == null)
        {
            wall = transform;
        }
        initialPosition = wall.position;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            isOpening = true;
        }
    }

    void Update()
    {
        // If the wall is set to open, move it towards the open position
        if (isOpening)
        {
            wall.position = Vector3.Lerp(wall.position, openPosition, Time.deltaTime * openSpeed);

            // Stop moving the wall once it reaches the target position
            if (Vector3.Distance(wall.position, openPosition) < 0.01f)
            {
                wall.position = openPosition;
                isOpening = false;
            }
        }
    }
}