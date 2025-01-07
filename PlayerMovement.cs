using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour //don't move horizontal input axis 
    //A and D should move you left and right
    //remove logic that finds out if 
{
    public float horizontalInput, verticalInput;
    public float turnSpeed = 10f;
    public float moveSpeed = 10f;
    public Room currentRoom;
    public CombatRoom currentCRoom;
    public TreasureRoom currentTRoom;
    public DiningRoom currentDRoom;

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
        /*
        // Get player input for both axes
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move the player based on the input along the x (right) and z (forward) axes
        Vector3 movement = new Vector3(0, 0, verticalInput); //originally horizontalInput for x-axis
        transform.Translate(movement * Time.deltaTime * moveSpeed, Space.World); //good for something like a moving platform or ghost NPC that can move through walls
        //transform.Translate doesn't work for collisions

        // Rotate the player based on horizontal input
        if (horizontalInput != 0)
        {
            //transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime); //snaps back once you release a/d
        }
        //Beginning of rotation code
        if (isRotating)
        {
            Quaternion currentRotation = Quaternion.Slerp( //
                previousRotation,
                Quaternion.Euler(new Vector3(0, _rotationByDirection[facingDirection], 0)),
                rotationTimer / RotationTime);

            transform.rotation = currentRotation;

            rotationTimer += Time.deltaTime;

            if (rotationTimer > RotationTime)
            {
                isRotating = false;
                rotationTimer = 0.0f;
                //SetFacingDirection(); // Snap to the final rotation after smooth rotation is complete
            }
        }
        else
        {
            // GetKeyDown is per-press basis. "Was the button pressed *this* frame?"
            bool rotateLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
            bool rotateRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
            // ensure one or the other is true, not both
            if (rotateLeft && !rotateRight)
            {
                TurnLeft();
            }
            else if (rotateRight && !rotateLeft)
            {
                TurnRight();
            }
            else
            /*
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Room roomInFacingDirection = NextRoomInDirection();
                if (roomInFacingDirection != null)
                {
                    StartMovement(roomInFacingDirection);
                }
            }

        }
        */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentRoom != null)
            {
                /*
                currentRoom.OnRoomSearched();
                */
            }
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
/*
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
    */

    
        private void OnTriggerEnter(Collider otherObject) //how can we accomodate this for diff types of rooms?
        {
            if (otherObject.CompareTag("NormalRoom"))
        {
            currentRoom = otherObject.GetComponent<Room>();
            //currentRoom.AssignPlayer(GameManager.userCapsule);
            currentRoom.OnRoomEntered();
            Debug.Log("Room entered");
        }
            else if (otherObject.CompareTag("CombatRoom"))
        {
            currentCRoom = otherObject.GetComponent<CombatRoom>();
            currentCRoom.OnRoomEntered();
            Debug.Log("Combat room entered");
        }
            else if (otherObject.CompareTag("DiningRoom"))
        {
            currentDRoom = otherObject.GetComponent<DiningRoom>();
            currentDRoom.OnRoomEntered();
            Debug.Log("Dining room entered");
        }
            else if (otherObject.CompareTag("TreasureRoom"))
        {
            currentTRoom = otherObject.GetComponent<TreasureRoom>();
            currentTRoom.OnRoomEntered();
            Debug.Log("Treasure room entered");
        }
    }

        private void OnTriggerExit(Collider otherObject)
    {
        if (otherObject.CompareTag("NormalRoom"))
        {
            Room exitingRoom = otherObject.GetComponent<Room>();
            exitingRoom.OnRoomExit();
            Debug.Log("Room exited");
            currentRoom = null;
        }
        else if (otherObject.CompareTag("CombatRoom"))
        {
            Room exitingCRoom = otherObject.GetComponent<CombatRoom>();
            exitingCRoom.OnRoomExit();
            Debug.Log("Combat room exited");
            currentCRoom = null;
        }
        else if (otherObject.CompareTag("DiningRoom"))
        {
            Room exitingDRoom = otherObject.GetComponent<DiningRoom>();
            exitingDRoom.OnRoomExit();
            Debug.Log("Dining room exited");
            currentDRoom = null;
        }
        else if (otherObject.CompareTag("TreasureRoom"))
        {
            Room exitingTRoom = otherObject.GetComponent<TreasureRoom>();
            exitingTRoom.OnRoomExit();
            Debug.Log("Treasure room exited");
            currentTRoom = null;
        }
    }
    
}
