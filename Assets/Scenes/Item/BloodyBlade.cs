using System;
using UnityEngine;

public class MeatyBlade : Item
{
    //Goal: attach the blade to the user + make the enemy bump into the user a couple extra times
    protected override void Awake()
    {
        base.Awake();
        description = "Use it to increase your die roll by 3 in most enemies, and increase your roll by 5 when fighting against the bear.";
        itemRarity = Rarity.Common; // Initialize item rarity
    }
    
    public override void UseItem(User user, Enemy enemy)
    {
        foreach (DieRoller die in user.Dice)
        {
            if (die.numberOfSides == enemy.Dice[0].numberOfSides)
            {
                die.Roll();
                if (enemy.name == "Bear")
                {
                    if (die.roll > die.numberOfSides / 2)
                    {
                        CRoom.ShowEAText();
                        CRoom.TmpTextComponent1.text = $"<color=red>{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, plus 5 from the {itemName}, with a total of {die.roll + 5}. Above average</color>";
                        StartCoroutine(InvokeHideEAText(CRoom, 5f));
                    }
                    else if (die.roll == die.numberOfSides / 2)
                    {
                        CRoom.ShowEAText();
                        CRoom.TmpTextComponent1.text = $"<color=red>{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, plus 5 from the {itemName}, with a total of {die.roll + 5}. Average</color>";
                        StartCoroutine(InvokeHideEAText(CRoom, 5f));
                    }
                    else
                    {
                        CRoom.ShowEAText();
                        CRoom.TmpTextComponent1.text = $"<color=red>{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, plus 5 from the {itemName}, with a total of {die.roll + 5}. Below average</color>";
                        StartCoroutine(InvokeHideEAText(CRoom, 5f));
                    }
                    enemy.health -= (die.roll + 5);
                }
                else {
                    if (die.roll > die.numberOfSides / 2)
                    {
                        CRoom.ShowEAText();
                        CRoom.TmpTextComponent1.text = $"<color=red>{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, plus 3 from the {itemName}, with a total of {die.roll + 3}. Above average</color>";
                        StartCoroutine(InvokeHideEAText(CRoom, 5f));
                    }
                    else if (die.roll == die.numberOfSides / 2)
                    {
                        CRoom.ShowEAText();
                        CRoom.TmpTextComponent1.text = $"<color=red>{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, plus 3 from the {itemName}, with a total of {die.roll + 3}. Average</color>";
                        StartCoroutine(InvokeHideEAText(CRoom, 5f));
                    }
                    else
                    {
                        CRoom.ShowEAText();
                        CRoom.TmpTextComponent1.text = $"<color=red>{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, plus 3 from the {itemName}, with a total of {die.roll + 3}. Below average</color>";
                        StartCoroutine(InvokeHideEAText(CRoom, 5f));
                    }
                    enemy.health -= (die.roll + 3);
                }
                enemy.IGH.OnHealthChange(enemy.health, enemy.Dice[0].numberOfSides);
                enemy.NormalRoll();
                user.EndOfTurn(enemy);

            }
        }
    }
}
