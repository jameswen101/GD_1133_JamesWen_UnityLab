using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float turnSpeed = 10f;
    public float moveSpeed = 10f;
    Room currentRoom;

    private Dictionary<Direction, int> _rotationByDirection = new()
    {
        { Direction.North, 0 },
        { Direction.East, 90 },
        { Direction.South, 180 },
        { Direction.West, 270 }
    };
    private Direction facingDirection;
    // Start is called before the first frame update
    // Code for rotation- if rotation doesn't work, change back to start

    private bool isRotating = false;
    // smooth rotation
    [SerializeField] private float RotationTime = 0.5f;
    private float rotationTimer = 0.0f;
    private Quaternion previousRotation;

    public void Setup()
    {
        // simple array of all directions
        Direction[] directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.North };
        // roll a random direction
        facingDirection = directions[UnityEngine.Random.Range(0, directions.Length)];
        // Update the transform
        SetFacingDirection();
    }

    private void SetFacingDirection()
    {
        // Note: transform.rotation is type "Quaternion", we hate working with those
        // Get the transform's rotation, use eulerAngles for easier math (Vector3)
        Vector3 facing = transform.rotation.eulerAngles;
        // Set the y value
        facing.y = _rotationByDirection[facingDirection];
        // save the rotation back, converting it to a Quaternion first
        transform.rotation = Quaternion.Euler(facing);
    }
    //End of rotation code
    // Update is called once per frame
    void Update()
    {
        // Get player input for both axes
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move the player based on the input along the x (right) and z (forward) axes
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movement * Time.deltaTime * moveSpeed, Space.World);

        // Rotate the player based on horizontal input
        if (horizontalInput != 0)
        {
            transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);
        }
        //Beginning of rotation code
        if (isRotating)
        {
            Quaternion currentRotation = Quaternion.Slerp(
                previousRotation,
                Quaternion.Euler(new Vector3(0, _rotationByDirection[facingDirection], 0)),
                rotationTimer / RotationTime);

            transform.rotation = currentRotation;

            rotationTimer += Time.deltaTime;

            if (rotationTimer > RotationTime)
            {
                isRotating = false;
                rotationTimer = 0.0f;
                SetFacingDirection(); // Snap to the final rotation after smooth rotation is complete
            }
        }
        else
        {
            // GetKeyDown is per-press basis. "Was the button pressed *this* frame?"
            bool rotateLeft = Input.GetKeyDown(KeyCode.A);
            bool rotateRight = Input.GetKeyDown(KeyCode.D);
            // ensure one or the other is true, not both
            if (rotateLeft && !rotateRight)
            {
                TurnLeft();
            }
            else if (rotateRight && !rotateLeft)
            {
                TurnRight();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentRoom != null)
                {
                    currentRoom.OnRoomSearched();
                }
            }
            /*
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Room roomInFacingDirection = NextRoomInDirection();
                if (roomInFacingDirection != null)
                {
                    StartMovement(roomInFacingDirection);
                }
            }
            */
        }


    }

    private Room NextRoomInDirection()
    {
        if (currentRoom == null)
            return null;

        switch (facingDirection)
        {
            case Direction.North:
                return currentRoom.north;
            case Direction.East:
                return currentRoom.east;
            case Direction.South:
                return currentRoom.south;
            case Direction.West:
                return currentRoom.west;
            default:
                Debug.LogError("Error: Unknown Direction!");
                return null;
        }
    }

    // Counterclockwise
    public void TurnLeft()
    {
        switch (facingDirection)
        {
            case Direction.South:
                facingDirection = Direction.East;
                break;
            case Direction.North:
                facingDirection = Direction.West;
                break;
            case Direction.East:
                facingDirection = Direction.North;
                break;
            case Direction.West:
                facingDirection = Direction.South;
                break;
        }
        StartRotating();
    }

    // Clockwise
    public void TurnRight()
    {
        switch (facingDirection)
        {
            case Direction.South:
                facingDirection = Direction.West;
                break;
            case Direction.North:
                facingDirection = Direction.East;
                break;
            case Direction.East:
                facingDirection = Direction.South;
                break;
            case Direction.West:
                facingDirection = Direction.North;
                break;
        }
        StartRotating();
    }

    private void StartRotating()
    {
        previousRotation = transform.rotation;
        isRotating = true;
    }
    //End of rotation code
    /*
        private void OnTriggerEnter(Collider otherObject) //how does the system know which one is enter and which one is exit?
        {
            currentRoom = otherObject.GetComponent<Room>();
            currentRoom.OnRoomEntered();
            Debug.Log("Room entered");
        }

        private void OnTriggerExit(Collider otherObject)
        {
            Room exitingRoom = otherObject.GetComponent<Room>();
            exitingRoom.OnRoomExit();
            Debug.Log("Room exited");
        }
    */
}
