using System;
using UnityEngine;

public class Shield : Item
{

    //Goal: attach shield to user
    //description = "Use this to halve the enemy's roll.";

    public override void UseItem(User user, Enemy enemy)
    {
        foreach (DieRoller die in user.Dice)
        {
            if (die.numberOfSides == enemy.Dice[0].numberOfSides)
            {
                user.normalRoll(enemy);
                enemy.IGH.OnHealthChange(enemy.health, enemy.Dice[0].numberOfSides);
                enemy.Dice[0].Roll();
                if (enemy.Dice[0].roll > enemy.Dice[0].numberOfSides / 2)
                {
                    CRoom.TmpTextComponent1.text = $"<color=red>{enemy.name} rolled a {enemy.Dice[0].numberOfSides} sided die for a result of {enemy.Dice[0].roll}, divided by 2 with the {itemName}, with a total of {enemy.Dice[0].roll / 2}. Above average</color>";
                    CRoom.ShowEAText();
                    StartCoroutine(InvokeHideEAText(CRoom, 5f));
                }
                else if (die.roll == die.numberOfSides / 2)
                {
                    CRoom.TmpTextComponent1.text = $"<color=red>{enemy.name} rolled a {enemy.Dice[0].numberOfSides} sided die for a result of {enemy.Dice[0].roll}, divided by 2 with the {itemName}, with a total of {enemy.Dice[0].roll / 2}. Average</color>";
                    CRoom.ShowEAText();
                    StartCoroutine(InvokeHideEAText(CRoom, 5f));
                }
                else
                {
                    CRoom.TmpTextComponent1.text = $"<color=red>{enemy.name} rolled a {enemy.Dice[0].numberOfSides} sided die for a result of {enemy.Dice[0].roll}, divided by 2 with the {itemName}, with a total of {enemy.Dice[0].roll / 2}. Below average</color>";
                    CRoom.ShowEAText();
                    StartCoroutine(InvokeHideEAText(CRoom, 5f));
                }
                user.health -= (enemy.Dice[0].roll/2);
                user.IGH.OnHealthChange(user.health, user.CalculateMaxHealth());
                user.EndOfTurn(enemy);
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();
        description = "This is the most powerful item in the game. Use this to reduce the enemy's health by 50%, and then, you can roll at full strength and they can't roll for that turn.";
        itemRarity = Rarity.Rare; // Initialize item rarity
    }

}
