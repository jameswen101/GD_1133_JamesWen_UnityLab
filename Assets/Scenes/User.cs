using System;
using System.Collections.Generic;
using UnityEngine;

public class User : Player
{
    public List<Item> ItemInventory = new List<Item>();
    public bool noItems = true;
    public new List<DieRoller> Dice = new();

    public void exchangeAttack(Enemy enemy)
    {
        bool rightChoice = false;
        if (!noItems)
        {
            String response = " ";
            do
            {
                Debug.Log("Do you wish to use any items?");
                response = Console.ReadLine();
                if (response.ToUpper() != "YES" && response.ToUpper() != "NO")
                {
                    Debug.Log("Please enter yes or no.");
                }
            } while (response.ToUpper() != "YES" && response.ToUpper() != "NO");

            if (response.ToUpper() == "YES")
            {
                String itemChoice = " ";
                do
                {
                    Debug.Log("Which item would you like to use?");
                    foreach (Item item in ItemInventory)
                    {
                        Debug.Log(item.itemName);
                    }
                    itemChoice = Console.ReadLine();
                    foreach (Item item in ItemInventory)
                    {
                        if (itemChoice.ToUpper() == item.itemName.ToUpper())
                        {
                            rightChoice = true;
                        }
                    }
                    if (!rightChoice)
                    {
                        Debug.Log("Please enter the right item name.");
                    }
                } while (!rightChoice);

                for (int itemNum = 0; itemNum < ItemInventory.Count; itemNum++) //foreach loop will cause an invalid operation exception here

                {
                    if (itemChoice.ToUpper() == ItemInventory[itemNum].itemName.ToUpper())
                    {
                        Debug.Log(ItemInventory[itemNum].asciiArt);
                        ItemInventory[itemNum].useItem(this, enemy);
                        ItemInventory.RemoveAt(itemNum);
                        if (ItemInventory.Count == 0)
                        {
                            noItems = true;
                        }
                    }
                }
            }
            else
            {
                normalRoll(enemy);
            }
        }
        else
        {
            normalRoll(enemy);
        }
    }

    void normalRoll(Enemy enemy)
    {
        foreach (DieRoller die in Dice)
        {
            if (die.numberOfSides == enemy.Dice[0].numberOfSides)
            {
                Debug.Log("__   _____  _   _ ____    _____ _   _ ____  _   _ \r\n\\ \\ / / _ \\| | | |  _ \\  |_   _| | | |  _ \\| \\ | |\r\n \\ V / | | | | | | |_) |   | | | | | | |_) |  \\| |\r\n  | || |_| | |_| |  _ <    | | | |_| |  _ <| |\\  |\r\n  |_| \\___/ \\___/|_| \\_\\   |_|  \\___/|_| \\_\\_| \\_|");
                //YOUR TURN
                die.Roll();
                if (die.roll > die.numberOfSides / 2)
                {
                    Debug.Log($"{name} rolled a {die.numberOfSides} sided die for a result of {die.roll}. Above average");
                }
                else if (die.roll == die.numberOfSides / 2)
                {
                    Debug.Log($"{name} rolled a {die.numberOfSides} sided die for a result of {die.roll}. Average");
                }
                else
                {
                    Debug.Log($"{name} rolled a {die.numberOfSides} sided die for a result of {die.roll}. Below average");
                }
                enemy.health -= die.roll;
                Debug.Log(" _____ _   _ _____ __  ____   ___ ____    _____ _   _ ____  _   _ \r\n| ____| \\ | | ____|  \\/  \\ \\ / ( ) ___|  |_   _| | | |  _ \\| \\ | |\r\n|  _| |  \\| |  _| | |\\/| |\\ V /|/\\___ \\    | | | | | | |_) |  \\| |\r\n| |___| |\\  | |___| |  | | | |    ___) |   | | | |_| |  _ <| |\\  |\r\n|_____|_| \\_|_____|_|  |_| |_|   |____/    |_|  \\___/|_| \\_\\_| \\_|");
                //ENEMY'S TURN
                enemy.Dice[0].Roll();
                if (enemy.Dice[0].roll > enemy.Dice[0].numberOfSides / 2)
                {
                    Debug.Log($"{enemy.name} rolled a {enemy.Dice[0].numberOfSides} sided die for a result of {enemy.Dice[0].roll}. Above average");
                }
                else if (die.roll == die.numberOfSides / 2)
                {
                    Debug.Log($"{enemy.name} rolled a {enemy.Dice[0].numberOfSides} sided die for a result of {enemy.Dice[0].roll}. Average");
                }
                else
                {
                    Debug.Log($"{enemy.name} rolled a {enemy.Dice[0].numberOfSides} sided die for a result of {enemy.Dice[0].roll}. Below average");
                }
                health -= enemy.Dice[0].roll;
                Debug.Log($"{health} vs {enemy.health}");
                if (enemy.health <= 0)
                {
                    enemy.enemyIsDead();
                }
            }
        }
    }

    public User(String name) : base(name)
    {
        row = 0;
        col = 0;
        position = new Vector2(0, 0);
        
    }
}      



