using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Room: MonoBehaviour
{
	public bool hasItem, hasMeat, hasEnemy = false;
    MapMgr mapMgr;
	public int row, col;
    [SerializeField] private GameObject NorthDoorway, EastDoorway, SouthDoorway, WestDoorway;
    public Room north, west, south, east;
    public int roomNum;
    internal User user;
    [SerializeField]
    List<String> Directions = new List<String>();
    TreasureRoom tRoom;
    DiningRoom dRoom;
    CombatRoom cRoom;
    public Room(int row, int col)
	{
		this.row = row;
		this.col = col;
        roomNum = row * 5 + col;
	}

    public void OnRoomSearched()
    {
            for (int i = 0; i < mapMgr.roomsInMap.Count; i++)
            {
                if (row == user.row && col == user.col)
                {
                    //Debug.Log($"{user.name} is in room at [{row}, {col}]");

                    if (mapMgr.roomsInMap[i].hasItem)
                    {
                        Debug.Log("This is a treasure room.");
                        //tRoom.giveItem();
                    }
                    else if (mapMgr.roomsInMap[i].hasMeat)
                    {
                        Debug.Log("This is a dining room.");
                        //dRoom.giveMeat();
                    }
                    else if (mapMgr.roomsInMap[i].hasEnemy)
                    {
                        Debug.Log("This is a combat room.");
                        //cRoom.showEnemy();
                    }
                    else
                    {
                        Debug.Log("This room is safe.");
                    }
                }
            }
    }

    public void OnRoomExit() 
    {
        /*
        String directionChoice = " ";
        bool validDirection = false; //initialize them here as the value restarts every time the function is called
        
        do
        {
            Debug.Log("Which direction would you like to go for your next room?");
            if (row > 0)
            {
                north = mapMgr.roomsInMap[roomNum - 5];
                Debug.Log("North");
                Directions.Add("North");
            }
            if (col > 0)
            {
                west = mapMgr.roomsInMap[roomNum - 1];
                Debug.Log("West");
                Directions.Add("West");
            }
            if (row < 4)
            {
                south = mapMgr.roomsInMap[roomNum + 5];
                Debug.Log("South");
                Directions.Add("South");
            }
            if (col < 4)
            {
                east = mapMgr.roomsInMap[roomNum + 1];
                Debug.Log("East");
                Directions.Add("East");
            }
            directionChoice = Console.ReadLine();
            foreach (String direction in Directions)
            {
                if (directionChoice.ToUpper() == direction.ToUpper())
                {
                    validDirection = true;
                } //if code ends
            } //foreach loop code ends
            if (!validDirection)
            {
                Debug.Log("Please enter a valid direction.");
            } //if code ends
        } while (!validDirection); //do-while code ends

        switch (directionChoice.ToUpper()) //if input is valid
        {
            case "WEST":
                Debug.Log("Moving west...");
                user.col -= 1;
                Vector2 wMove = new Vector2(0, -1);
                user.position += wMove;
                break;

            case "NORTH":
                Debug.Log("Moving north...");
                user.row -= 1;
                Vector2 nMove = new Vector2(-1, 0);
                user.position += nMove;
                break;

            case "SOUTH":
                Debug.Log("Moving south...");
                user.row += 1;
                Vector2 sMove = new Vector2(1, 0);
                user.position += sMove;
                break;

            case "EAST":
                Debug.Log("Moving east...");
                user.col += 1;
                Vector2 eMove = new Vector2(0, 1);
                user.position += eMove;
                break;
        } //switch code ends
    */
        Debug.Log("You are about to exit the current room.");
    }

    public void OnRoomEntered()
    {
        Debug.Log($"You have just entered this new room. \nLet's search this room for items and enemies!");
        showSearch();
    }

    void showSearch()
    {
        Debug.Log("                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                  ....................                                              \r\n                               ....-*@@@@@@@@@@@@@@@@%=:...                                         \r\n                            ..:+%@@@@@@@@@@@@@@@@@@@@@@@@@#-.....                                   \r\n                          .-*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%+:.......                             \r\n                       ..=%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#:.....                             \r\n                     ..+@@@@@@@@@@@@@@@#=:.......-+%@@@@@@@@@@@@@@%:...                             \r\n                   ..=%@@@@@@@@@@@#=..................:+%@@@@@@@@@@@#:..                            \r\n                  ..*@@@@@@@@@@#:.........................=#@@@@@@@@@@=......                       \r\n                ..:%@@@@@@@@@+:.......:+++:. ...............-%@@@@@@@@@*.....                       \r\n               ..-%@@@@@@@@#.......=%@@@@@@. ............ ....-@@@@@@@@@#.....                      \r\n               .-%@@@@@@@@=......#@@@@@@@@*. ............  .....*@@@@@@@@*...                       \r\n               :#@@@@@@@%-.....+@@@@@@@@%=..                  ...*@@@@@@@@=..                       \r\n              .+@@@@@@@@-.....#@@@@@@@%=....                  ....*@@@@@@@@:.                       \r\n             ..@@@@@@@@=.....%@@@@@@*:.....                   .....%@@@@@@@*.                       \r\n             .+@@@@@@@#.....#@@@@@#:.......                   .....:@@@@@@@@.                       \r\n             .@@@@@@@@=.  .-@@@@@=.........                   ......#@@@@@@@-..                     \r\n             :@@@@@@@@-....#@@@@-..........                   ......+@@@@@@@#..                     \r\n             :@@@@@@@%-....#@@@+...........                   ......=@@@@@@@#.                      \r\n             :@@@@@@@%-....#@@*......                         ......=@@@@@@@#..                     \r\n             .@@@@@@@@-....#@%=......                         ......*@@@@@@@+..                     \r\n             .#@@@@@@@+....*@#.......                         .....:%@@@@@@@:.                      \r\n             .-@@@@@@@@:...:#:.......                         .....=@@@@@@@@.                       \r\n             ..%@@@@@@@%.......                               ....:@@@@@@@@=.                       \r\n               -@@@@@@@@*......                               ...:@@@@@@@@#:.                       \r\n               .+@@@@@@@@*....                                ..-%@@@@@@@%-..                       \r\n               ..*@@@@@@@@#:..                               ..=%@@@@@@@@=...                       \r\n                ..#@@@@@@@@@*...                           ..:%@@@@@@@@@-....                       \r\n                ...+@@@@@@@@@%+.......                  ...:#@@@@@@@@@@@%-..........                \r\n                ....-%@@@@@@@@@@#=......................:+%@@@@@@@@@@@@@@@#:........                \r\n                ......+@@@@@@@@@@@@%*=..............:+*%@@@@@@@@@@@@@@@@@@@@*.......                \r\n                ........+@@@@@@@@@@@@@@@%%%####%%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@+....                 \r\n                ..........=%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-...                \r\n                .............*%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#-:#@@@@@@@@@@@@@@@@@@-.......          \r\n                       .........=+%@@@@@@@@@@@@@@@@@@@@@#+:.....-%@@@@@@@@@@@@@@@@@#-.....          \r\n                       ..............:-=*#%@@@@@%#+--:............=@@@@@@@@@@@@@@@@@@#.....         \r\n                       ..................................  .........+@@@@@@@@@@@@@@@@@@*..          \r\n                                                       ..     ........*@@@@@@@@@@@@@@@@@*:          \r\n                                                              .........:*@@@@@@@@@@@@@@@@-          \r\n                                                              ...........-#@@@@@@@@@@@@@@-          \r\n                                                              .............-@@@@@@@@@@@@*:          \r\n                                                                     ........+%@@@@@@@@+..          \r\n                                                                     ..........-+***+-....          \r\n                                                                     .....................          \r\n                                                                     .....................          \r\n                                                                                                    \r\n                                                                                                    ");
        //shows magnifying glass
    }

}
        