using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMgr : MonoBehaviour
{
    [SerializeField]
    public Room[,] map = new Room[5, 5]; //make the 5x5 map
    [SerializeField]
    List<Room> roomTypes = new List<Room>();
    [SerializeField] float roomSize = 3;
    [SerializeField] Dictionary<Room, Vector2> roomDir = new Dictionary<Room, Vector2>(); //stores a list that holds the 4 types of rooms
    [SerializeField] public List<Room> roomsInMap = new List<Room>();
    Vector3 offset = new Vector3(0.01f, 0, 0.01f); // Small offset to avoid z-fighting

    //add the 4 types of rooms into the list

    public MapMgr()
    {
    }
    public void setUpMap(Room[,] map)
    {
        // var mapRoomRepresenation = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // mapRoomRepresenation.transform.position = new Vector3(x,0,z);
        for (int row = 0; row < map.GetLength(0); row++)
        {
            for (int col = 0; col < map.GetLength(1); col++)
            {
                //set conditions for when different types of rooms are made
                bool isTreasureRoom = (row == 2 || col == 2) && !(row == 2 && col == 2) && !(row == 2 && col == 4) && !(row == 4 && col == 2);
                bool isDiningRoom = (row == 0 && col == 4) || (row == 4 && col == 0) || (row == 2 && col == 4) || (row == 4 && col == 2);
                bool isCombatRoom = row == col && row > 0 && col > 0;
                Vector2 coords = new Vector2(row, col);
                //make different types of rooms when condiion is matching
                if (isTreasureRoom) //excludes (2,2), (2,4), (4,2)
                { 
                    Room tRoomRepresentation = Instantiate(roomTypes[2], transform);
                    tRoomRepresentation.transform.position = new Vector3(row * roomSize, 0, col * roomSize) + offset;
                    roomDir.Add(tRoomRepresentation, coords);
                    roomsInMap.Add(tRoomRepresentation);
                    Debug.Log($"Treasure room made at ({row}, {col})");
                }
                else if (isDiningRoom) //for (0,4), (4,0), (2,4), and (4,2)
                {
                    Room dRoomRepresentation = Instantiate(roomTypes[3], transform);
                    dRoomRepresentation.transform.position = new Vector3(row * roomSize, 0, col * roomSize) + offset;
                    roomDir.Add(dRoomRepresentation, coords);
                    roomsInMap.Add(dRoomRepresentation);
                    Debug.Log($"Dining room made at ({row}, {col})");
                }
                else if (isCombatRoom) //doubles excluding (0,0)
                {
                    Room cRoomRepresentation = Instantiate(roomTypes[1], transform);
                    cRoomRepresentation.transform.position = new Vector3(row * roomSize, 0, col * roomSize) + offset;
                    roomDir.Add(cRoomRepresentation, coords);
                    roomsInMap.Add(cRoomRepresentation);
                    Debug.Log($"Combat room made at ({row}, {col})");
                }
                else
                {
                    Room nRoomRepresentation = Instantiate(roomTypes[0], transform);
                    nRoomRepresentation.transform.position = new Vector3(row * roomSize, 0, col * roomSize) + offset;
                    roomDir.Add(nRoomRepresentation, coords);
                    roomsInMap.Add(nRoomRepresentation);
                    Debug.Log($"Normal room made at ({row}, {col})");
                }

            }
        }

    }
}