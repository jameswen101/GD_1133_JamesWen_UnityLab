using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : Player
{
    public List<Item> ItemInventory = new List<Item>();
    [HideInInspector]
    public bool noItems = true;
    public new List<DieRoller> Dice = new();
    [HideInInspector]
    public int maxHealth;
    private CombatRoom CRoom;
    public Material DefaultMaterial;
    //add variables to store how many of each item does the user have?

    private void Start()
    {
        row = 0;
        col = 0;
        position = new Vector2(0, 0);
    }

    public int CalculateMaxHealth()
    {
        for (int i = 0; i < Dice.Count; i++)
        {
            maxHealth += Dice[i].numberOfSides;
        }
        return maxHealth;
    }

    public void exchangeAttack(Enemy enemy) //for choosing items, you can have items be chosen by clicking on a button that contains the items the user has
        //But a new button has to be made every time the user gets an item?
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
                        ItemInventory[itemNum].UseItem(this, enemy);
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
                enemy.NormalRoll();
                EndOfTurn(enemy);
            }
        }
        else
        {
            normalRoll(enemy);
            enemy.NormalRoll();
            EndOfTurn(enemy);
        }
    }

    public void normalRoll(Enemy enemy)
    {
        
        foreach (DieRoller die in Dice)
        {
            if (die.numberOfSides == enemy.Dice[0].numberOfSides)
            {
                CRoom.TmpTextComponent1.text = "<color=red>YOUR TURN</color>";
                CRoom.TmpTextComponent1.font = CRoom.DisplayFont;
                CRoom.ShowEAText();
                StartCoroutine(InvokeHideEAText(CRoom, 2f));
                die.Roll(); //try visualizing it
                if (die.roll > die.numberOfSides / 2)
                {
                    CRoom.TmpTextComponent1.text = $"<color=red>{name} rolled a {die.numberOfSides} sided die for a result of {die.roll}. Above average</color>";
                    CRoom.ShowEAText();
                    StartCoroutine(InvokeHideEAText(CRoom, 5f));
                }
                else if (die.roll == die.numberOfSides / 2)
                {
                    CRoom.TmpTextComponent1.text = $"<color=red>{name} rolled a {die.numberOfSides} sided die for a result of {die.roll}. Average</color>";
                    CRoom.ShowEAText();
                    StartCoroutine(InvokeHideEAText(CRoom, 5f));
                }
                else
                {
                    CRoom.TmpTextComponent1.text = $"<color=red>{name} rolled a {die.numberOfSides} sided die for a result of {die.roll}. Below average</color>";
                    CRoom.ShowEAText();
                    StartCoroutine(InvokeHideEAText(CRoom, 5f));
                }
                enemy.health -= die.roll; //show that in the health bar
                IGH.OnHealthChange(enemy.health, enemy.Dice[0].numberOfSides);            
            }
        }

        
    }

    public void EndOfTurn(Enemy enemy)
    {
        CRoom.TmpTextComponent2.text = $"<color=red>{health} vs {enemy.health}</color>";
        CRoom.ShowHealthText();
        StartCoroutine(InvokeHideHealthText(CRoom, 2f));
        if (enemy.health <= 0)
        {
            CRoom.EnemyIsDead(enemy);
        }
    }

    private IEnumerator InvokeHideEAText(CombatRoom room, float delay) 
    {
        yield return new WaitForSeconds(delay);
        room.HideEAText(); // Call the method on the CRoom instance
    }

    private IEnumerator InvokeHideHealthText(CombatRoom room, float delay)
    {
        yield return new WaitForSeconds(delay);
        room.HideHealthText(); // Call the method on the CRoom instance
    }
    public User(String name) : base(name)
    {
        
        
    }
}      



