using System;
using UnityEngine;

public class Shield : Item
{
    public Shield()
    {
        description = "Use this to halve the enemy's roll.";
        asciiArt = "  |\\ _..--.._ /|\r\n  |############|\r\n   )##########(\r\n._/##.'//\\\\'.##\\_.\r\n .__)#((()))#(__.\r\n  \\##'.\\\\//.'##/\r\n   \\####\\/####/\r\n   /,.######.,\\\r\n  (  \\##__##/  )\r\n      \"(\\/)\"\r\n        )("; 
        //shows a shield
    }

    public override void useItem(User user, Enemy enemy)
    {
        foreach (DieRoller die in user.Dice)
        {
            if (die.numberOfSides == enemy.Dice[0].numberOfSides)
            {
                Debug.Log("__   _____  _   _ ____    _____ _   _ ____  _   _ \r\n\\ \\ / / _ \\| | | |  _ \\  |_   _| | | |  _ \\| \\ | |\r\n \\ V / | | | | | | |_) |   | | | | | | |_) |  \\| |\r\n  | || |_| | |_| |  _ <    | | | |_| |  _ <| |\\  |\r\n  |_| \\___/ \\___/|_| \\_\\   |_|  \\___/|_| \\_\\_| \\_|");
                //YOUR TURN
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
                Debug.Log(" _____ _   _ _____ __  ____   ___ ____    _____ _   _ ____  _   _ \r\n| ____| \\ | | ____|  \\/  \\ \\ / ( ) ___|  |_   _| | | |  _ \\| \\ | |\r\n|  _| |  \\| |  _| | |\\/| |\\ V /|/\\___ \\    | | | | | | |_) |  \\| |\r\n| |___| |\\  | |___| |  | | | |    ___) |   | | | |_| |  _ <| |\\  |\r\n|_____|_| \\_|_____|_|  |_| |_|   |____/    |_|  \\___/|_| \\_\\_| \\_|");
                //ENEMY'S TURN
                enemy.Dice[0].Roll();
                if (enemy.Dice[0].roll > enemy.Dice[0].numberOfSides / 2)
                {
                    Debug.Log($"{enemy.name} rolled a {enemy.Dice[0].numberOfSides} sided die for a result of {enemy.Dice[0].roll}, divided by 2 with the {itemName}, with a total of {enemy.Dice[0].roll/2}. Above average");
                }
                else if (die.roll == die.numberOfSides / 2)
                {
                    Debug.Log($"{enemy.name} rolled a {enemy.Dice[0].numberOfSides} sided die for a result of {enemy.Dice[0].roll}, divided by 2 with the {itemName}, with a total of {enemy.Dice[0].roll / 2}. Average");
                }
                else
                {
                    Debug.Log($"{enemy.name} rolled a {enemy.Dice[0].numberOfSides} sided die for a result of {enemy.Dice[0].roll}, divided by 2 with the {itemName}, with a total of {enemy.Dice[0].roll / 2}. Below average");
                }
                user.health -= (enemy.Dice[0].roll/2);
                Debug.Log($"{user.health} vs {enemy.health}");
            }
        }
    }
}
