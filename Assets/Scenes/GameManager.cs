﻿using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private MapMgr mapMgr; //prefab

    private MapMgr mMgrRef; //code reference

    [SerializeField]
    private PlayerMovement userCapsule;

    private PlayerMovement playerMove;

    bool allEnemiesDefeated;

    private void Start()
    {
        transform.position = Vector3.zero;
        mMgrRef = Instantiate(mapMgr, transform);
        mMgrRef.setUpMap(mMgrRef.map);
        SpawnPlayer();
        PlayGame();
    }


    User user; //declaring player object for user

    Room currentRoom = new Room(0,0);

    TreasureRoom tRoom;
    DiningRoom dRoom;
    CombatRoom cRoom;

    private void SpawnPlayer()
    {
        Debug.Log("GameManager SpawnPlayer Begins");
        Room startingRoom = mMgrRef.roomsInMap[0];
        playerMove = Instantiate(userCapsule, transform);
        Vector3 vector3 = new Vector3(startingRoom.row, 0, startingRoom.col);
        playerMove.transform.position = vector3;
    }



    public void PlayGame()
    {
        /*
        //Game setup
        Debug.Log("__        __   _                            _               \r\n\\ \\      / /__| | ___ ___  _ __ ___   ___  | |_ ___         \r\n \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\ | __/ _ \\        \r\n  \\ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) |       \r\n _ \\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|  \\__\\___/  _     \r\n| | | |_   _ _ __ | |_(_)_ __   __ _  __      _(_) |_| |__  \r\n| |_| | | | | '_ \\| __| | '_ \\ / _` | \\ \\ /\\ / / | __| '_ \\ \r\n|  _  | |_| | | | | |_| | | | | (_| |  \\ V  V /| | |_| | | |\r\n|_|_|_|\\__,_|_| |_|\\__|_|_| |_|\\__, |   \\_/\\_/ |_|\\__|_| |_|\r\n|  _ \\(_) ___ ___| |           |___/                        \r\n| | | | |/ __/ _ \\ |                                        \r\n| |_| | | (_|  __/_|                                        \r\n|____/|_|\\___\\___(_)                                        ");
        //Welcome to Hunting with Dice!
        Debug.Log("__        ___           _   _                              \r\n\\ \\      / / |__   __ _| |_( )___   _   _  ___  _   _ _ __ \r\n \\ \\ /\\ / /| '_ \\ / _` | __|// __| | | | |/ _ \\| | | | '__|\r\n  \\ V  V / | | | | (_| | |_  \\__ \\ | |_| | (_) | |_| | |   \r\n   \\_/\\_/  |_| |_|\\__,_|\\__|_|___/  \\__, |\\___/ \\__,_|_|   \r\n _ __   __ _ _ __ ___   __|__ \\     |___/                  \r\n| '_ \\ / _` | '_ ` _ \\ / _ \\/ /                            \r\n| | | | (_| | | | | | |  __/_|                             \r\n|_| |_|\\__,_|_| |_| |_|\\___(_)                             ");
        //What's your name?
        String userName = " ";
        userName = Console.ReadLine();
       

        //let user freely enter the die sizes they want + cpu uses the same dice
        int number = 0;

        Debug.Log("                                                                                               -%@@-\r\n                                                                                          ..*@@@@@@@\r\n                                                                                      .-#@@@@@@@#-..\r\n                                                                                ...=#@@@@@@@*-...   \r\n                                                                             .:+%@@@@@@@+:..        \r\n                    ........:...                                       ...-*@@@@@@@%=:..            \r\n                  ..=@@@@@@@@@@#.                                   .:+%@@@@@@@@*..                 \r\n                .-@@@@@@@@@@@@@@@+.                           ...-*@@@@@@@@@*.....                  \r\n               :@@@@@@@@@@@@@@@@@@#..                     ..:=%@@@@@@@@@@@+:.                       \r\n             .=@@@@@@@@@@@@@@@@@@@@@:........       ...:=#@@@@@@@@@@@@@*..                          \r\n            ..@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%.    ..#@@@@@@@@@@@@@@@@@#.                            \r\n            .#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@...*#@@@@@@@@@@@@@@@@@@#-..                            \r\n           .:@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%. .-@@@@@@@@@@@@@@@@@@@*.                               \r\n           .#@@@@@@@@@@@@@@@@@@@@@@@*.....#@#.%@@@@@@@#:=@@@@@@@@@@#.                               \r\n           ..*@@@@@@@@@@@@@@@@@@@@@@..  .@@@@@@@@@@@+%-:@@@@@@@@%=...                               \r\n            .:@@@@@@@@@@@@@@@@@@@@@@@...*@@@@@@@@@%@-+=+@@@@@@:.                                    \r\n          ..:@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#-:.:@@@@@@:.                                     \r\n        .:@@%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-. .#@@@@@#.                                      \r\n        .#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*...-@@@@@@=.                                      \r\n       ..%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-   -@@@@@@#.                                       \r\n      .=@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%:.=@@@@@+.:@@@@@@@-                                        \r\n     .*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@+  .:@@@@@@@@@@@@@@%.                                        \r\n  ..:#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*. .-@@@@@@@@@@@@@@@-                                         \r\n  .*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#:+:#@@@@@@@@@@@@@@@#.                                         \r\n .=@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-.                                         \r\n .%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#.                                         \r\n :@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@=.                                         \r\n.%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-.                                         \r\n-@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@=.                                          \r\n=@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#.                                           \r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@+..                                           \r\n=@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@:.                                             \r\n:@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*:                                               \r\n.@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#=:...                                                \r\n.@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%*+-..                                                         \r\n.@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*.                                                             \r\n.@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@=                                                             \r\n.%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@:                                                            \r\n.#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%..                                                          \r\n.+@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%.                                                          ");
        //show picture of a hunter
        Debug.Log("You are a hunter who loves meat but has no money, and hunting is your only solution for feeding yourself. However, you will be facing four hungry apex predators that will attack you. \n But first, you will choose the size of the four dice that decide how much you and the predators can attack each other:");
        for (int count = 0; count < 4; count++)
        {
            if (count == 0)
            {
                do
                {
                    Debug.Log("How many sides do you want in this die?");
                    number = int.Parse(Console.ReadLine());
                    if (number < 6)
                    { //in the case of Dice[0], the only limit is that the # of sides must be 6+
                        Debug.Log("Please enter a number not smaller than 6.");
                    } //if code ends
                } while (number < 6); //do-while loop code ends
            }

            else
            {
                do
                {
                    Debug.Log("How many sides do you want in this die?");
                    number = int.Parse(Console.ReadLine());
                    if (number < 6 || number <= user.Dice[count - 1].numberOfSides)
                    { //the number of sides in this die must be larger than the last die
                        Debug.Log("Please enter a number not smaller than 6 or your previous die."); //the size of each next die the user inputs must be larger than the last one
                    } //if code ends
                } while (number < 6 || number <= user.Dice[count - 1].numberOfSides); //do-while loop code ends
            }
            user.Dice.Add(new DieRoller(number)); //add die to user's dice list
        } //for loop code ends

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Empty room searched");
        }
        */

        //cRoom.addDiceHealth();
        mapMgr.setUpMap(mapMgr.map);
      

        //Game officially begins here
        if (cRoom.enemies[0].health <= 0 && cRoom.enemies[1].health <= 0 && cRoom.enemies[2].health <= 0 && cRoom.enemies[3].health <= 0)
        {
            allEnemiesDefeated = true;
            endOfGame();
        }
        else
        {
            allEnemiesDefeated = false;
        }
        while (user.health > 0 && !allEnemiesDefeated)
        {
            /*
            currentRoom.OnRoomSearched();
            if (user.health > 0 && !allEnemiesDefeated)
            {
                currentRoom.OnRoomExit();
                currentRoom.row = user.row;
                currentRoom.col = user.col;
                currentRoom.OnRoomEntered();
            }
            */
        }
        //Game ends
        endOfGame();
    }


    

    void endOfGame()
    {
        Debug.Log(" _____ _            _____           _ \r\n|_   _| |__   ___  | ____|_ __   __| |\r\n  | | | '_ \\ / _ \\ |  _| | '_ \\ / _` |\r\n  | | | | | |  __/ | |___| | | | (_| |\r\n  |_| |_| |_|\\___| |_____|_| |_|\\__,_|");
        //THE END
        if (user.health > 0 && allEnemiesDefeated)
        {
            Debug.Log($"Congratulations {user.name}! You have won with {user.health} health points remaining and have successfully defeated all apex predators! Time to cook up a nice feast with all your prey!");
            Debug.Log("_          _\r\n                           (c)___c____(c)\r\n                            \\ ........../\r\n                             |.........|\r\n                              |.......|\r\n                              |.......|\r\n                              |=======|\r\n                              |=======|\r\n                             __o)\"\"\"\"::?\r\n                            C__    c)::;\r\n                               >--   ::     /\\\r\n                               (____/      /__\\\r\n                               } /\"\"|      |##|\r\n                    __/       (|V ^ )\\     |##|\r\n                    o | _____/ |#/ / |     |##|\r\n           @        o_|}|_____/|/ /  |     |##|\r\n                          _____/ /   |     !!\r\n              ======ooo}{|______)#   |     /`'\\\r\n          ~~ ;    ;          ###---|8     \"\"\r\n        __;_____;____        ###====     /:|\\\r\n       (///0///@///@///)       ###@@@@|\r\n       |~~~~~~~~~~~~~~~|       ###@@@@|\r\n        \\             /        ###@@@@|               +\r\n         \\___________/         ###xxxxx      /\\      //\r\n           H H   H  H          ###|| |      /  \\    //\r\n           H H   H  H           | || |     /____\\  /~^\r\n           H H   H  H           C |C |     |@@| /__|#|_\r\n           H H   H  H            || ||    /_|@@|_/___|#|/|\r\n v    \\/   H(o) (o) H            || ::   |:::::::::::::|#|\r\n ~    ~~  (o)      (o)        Ccc__)__)  |ROMAN CANDLES|#|\r\n  \\|/      ~   @* & ~                    |:::::::::::::|/  \\|/\r\n   ~           \\|/        !!        \\ !/  ~~~~~~~~~~~    ~\r\n               ~        ~         ~           ~~\r\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
        else if (user.health <= 0 && !allEnemiesDefeated)
        {
            Debug.Log("_  /)\r\n                 mo / )\r\n                 |/)\\)\r\n                  /\\_\r\n                  \\__|=\r\n                 (    )\r\n                 _)(_\r\n           ____/      \\\\____\r\n          |                  ||\r\n          |  _     _   _   ||\r\n          | | \\     |   | \\  ||\r\n          | |  |    |   |  | ||\r\n          | |_/     |   |_/  ||\r\n          | | \\     |   |    ||\r\n          | |  \\    |   |    ||\r\n          | |   \\. |. | .  ||\r\n          |                  ||\r\n  *       | *   *    * *   |**      **\r\n   \\))ejm96/.,(//,,..,,\\||(,,.,\\\\,.((//");
            //Show picture of tombstone
            Debug.Log($"Congratulations apex predators! The 4 of you have officially hunted {user.name} and you can enjoy them for dinner! \n Who is still alive to eat the remains of {user.name}?");
            foreach (Enemy enemy in cRoom.enemies)
            {
                if (enemy.health > 0)
                {
                    Debug.Log($"{enemy.asciiArt}");
                }
                Debug.Log($"{enemy.name} has won with {enemy.health} remaining.");
            }
        }
        else
        {
            Debug.Log($"Seems like both you and all 4 apex predators have succumbed to your respective injuries. \nR.I.P. {user.name} and all apex predators...");
        }
        Debug.Log(" _____ _                 _                           __            \r\n|_   _| |__   __ _ _ __ | | __  _   _  ___  _   _   / _| ___  _ __ \r\n  | | | '_ \\ / _` | '_ \\| |/ / | | | |/ _ \\| | | | | |_ / _ \\| '__|\r\n  | | | | | | (_| | | | |   <  | |_| | (_) | |_| | |  _| (_) | |   \r\n  |_| |_| |_|\\__,_|_| |_|_|\\_\\  \\__, |\\___/ \\__,_| |_|  \\___/|_|   \r\n       _             _          |___/                              \r\n _ __ | | __ _ _   _(_)_ __   __ _| |                              \r\n| '_ \\| |/ _` | | | | | '_ \\ / _` | |                              \r\n| |_) | | (_| | |_| | | | | | (_| |_|                              \r\n| .__/|_|\\__,_|\\__, |_|_| |_|\\__, (_)                              \r\n|_|            |___/         |___/                                 ");
        //show picture of person cooking dinner

    }

}
