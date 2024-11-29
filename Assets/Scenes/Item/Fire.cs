using System;
using UnityEngine;

public class Fire : Item
{
    //Goal: add fire on top on enemy


    public override void UseItem(User user, Enemy enemy)
    {
        foreach (DieRoller die in user.Dice)
        {
            if (die.numberOfSides == enemy.Dice[0].numberOfSides)
            {
                die.Roll();
                if (die.roll > die.numberOfSides / 2)
                {
                    CRoom.ShowEAText();
                    CRoom.TmpTextComponent1.text = $"<color=red>{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, multiplied by 1.5 with {itemName}, with a total of {die.roll * 1.5}. Above average</color>";
                    StartCoroutine(InvokeHideEAText(CRoom, 5f));
                }
                else if (die.roll == die.numberOfSides / 2)
                {
                    CRoom.ShowEAText();
                    CRoom.TmpTextComponent1.text = $"<color=red>{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, multiplied by 1.5 with {itemName}, with a total of {die.roll * 1.5}. Average</color>";
                    StartCoroutine(InvokeHideEAText(CRoom, 5f));
                }
                else
                {
                    CRoom.ShowEAText();
                    CRoom.TmpTextComponent1.text = $"<color=red>{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, multiplied by 1.5 with {itemName}, with a total of {die.roll * 1.5}. Below average</color>";
                    StartCoroutine(InvokeHideEAText(CRoom, 5f));
                }
                enemy.health -= (die.roll + (die.roll/2));
                enemy.IGH.OnHealthChange(enemy.health, enemy.Dice[0].numberOfSides);
                enemy.NormalRoll();
                user.EndOfTurn(enemy);
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();
        description = "Use this to multiply your die rolls by 1.5.";
        itemRarity = Rarity.Common; // Initialize item rarity
    }

}
