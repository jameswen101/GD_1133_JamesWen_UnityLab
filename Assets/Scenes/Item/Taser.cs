﻿using System;
using UnityEngine;

public class Taser : Item
{

    public Taser()
    {
        asciiArt = "                                                                                                    \r\n                                                                                                    \r\n                                          ..:=+****=..    .... ..:.                                 \r\n                                        ..-##%%%%%%%:.  ..-:...:=-.                                 \r\n                                       .:+%###%%%%%#:...:=+:..-+=.....                              \r\n                                       .+%####%%%%%%*.=-+++:.=++=..:=.                              \r\n                                       =%######%%%=. .:=:-=-+-.+:.-+:.                              \r\n                                     .:%%#####%%%%+.  ...=++:.==:+++:.  ....                        \r\n                                     .%########%%%%-....:+-...++=:-=:..:#%%*.                       \r\n                                   ..#%########%%%%%+...::...:+=..---=%#%%%%%=.                     \r\n                                 ...*%###########%%%%%#-.....=........#%##%%%%-..                   \r\n                                 ..=#%#############%%%%%%%#=:......:*%%###%%%%#..                   \r\n                                 ..+%%%###############%%%%%%%%###%%%%#####%%%%#..                   \r\n                                 ..-#%%%%%%%##################%%##########%%%%*..                   \r\n                                 ....:+#%%%%%%%%%#######################%%%%%%:..                   \r\n                               ...:+**+%@@%%%%%%%%%#####################%%%%%-.                     \r\n                               ..:++*#%%%%%%@@@%%%%%%%%%%%############%%%%%%=..                     \r\n                               ..=+*#%%%%%%%%%%%@@@%%%%%%%%%%%########%%%%%+.                       \r\n                              ..=+**%%%%%%%%%%%%%%%@@@@%%%%%%%%%######%%%%*:.                       \r\n                              .-++*#%%%%%%%%%%%%%%%%%%%@@@@@%%%%%%%%%#%%%#-..                       \r\n                              .+**#%%%%%%%%%%%%%%%%%%%%%%%%@@@@@%%%%%%%%%=..                        \r\n                              ..-=#%%%%%%%%%%%%%%%%%%%%%%%%%%%%@@@+-+##*:...                        \r\n                               ..-#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%+........                          \r\n                               ..=%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*..                                 \r\n                               .:#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#-..                                 \r\n                               .:%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*...                                 \r\n                               .-%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#:.                                   \r\n                               .=%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#..                                   \r\n                               .+%%%%%%%%%%%%%%%%%%%%%%%%%%%%%=..                                   \r\n                            ...-*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%=:..                                  \r\n                            .-%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%+.                                  \r\n                            .-#%############################%%%%+.                                  \r\n                            .-#%#############################%%%+.                                  \r\n                            .-%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%+.                                  \r\n                            .:%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%=..                                 \r\n                            ....+%@@@@@@@@@@@@@@@@@@@@@@@@@@@@....                                  \r\n                               .+%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.                                     \r\n                            ..=*#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*+:.                                  \r\n                            .-#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%+.                                  \r\n                            .-#%############################%%%%+.                                  \r\n                            .-#%#############################%%%+.                                  \r\n                            .-%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%+.                                  \r\n                            ..*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#-..                                 \r\n                            ....+%%%%%%%%%%%%%%%%%%%%%%@@@@@@@....                                  \r\n                              ..+%%%%%%%%%%%%%%%%%%%%%%%%%%%%%..                                    \r\n                            .:#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#=..                                 \r\n                            .-#%#############################%%%+.                                  \r\n                            .-#%############################%%%%+.                                  \r\n                            .-#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%%%+..                                 \r\n                            .:%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%+.                                  \r\n                            ..=*#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*=...                                 \r\n                               .=%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.                                     \r\n                               ..=++++++++++++++++++++++++++=:                                      \r\n                                                                                                    \r\n                                                                                                    ";
        description = "This is the most powerful item in the game. Use this to reduce the enemy's health by 50%, and then, you can roll at full strength and they can't roll for that turn.";
    }

    public override void useItem(User user, Enemy enemy)
    {
        Debug.Log($"BUZZZZZZZZZ! \n{enemy.name} will be frozen for this turn and can't attack you!");
        enemy.health /= 2;
        Debug.Log($"{enemy.name} hasn't recovered from the taser yet! Let's give the predator another heavy blow!");
        foreach (DieRoller die in user.Dice)
        {
            if (die.numberOfSides == enemy.Dice[0].numberOfSides)
            {
                die.Roll();
                if (die.roll > die.numberOfSides / 2)
                {
                    Debug.Log($"{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}. Above average");
                }
                else if (die.roll == die.numberOfSides / 2)
                {
                    Debug.Log($"{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}. Average");
                }
                else
                {
                    Debug.Log($"{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}. Below average");
                }
                enemy.health -= die.roll;
                Debug.Log($"{user.health} vs {enemy.health}");
            }
        }
    }
}