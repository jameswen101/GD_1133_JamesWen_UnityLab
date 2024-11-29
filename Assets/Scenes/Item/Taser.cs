using System;
using UnityEngine;

public class Taser : Item
{
    //Goal: attach taser to user
    protected override void Awake()
    {
        base.Awake();
        description = "This is the most powerful item in the game. Use this to reduce the enemy's health by 50%, and then, you can roll at full strength and they can't roll for that turn.";
        itemRarity = Rarity.Rare; // Initialize item rarity
    }

    public override void UseItem(User user, Enemy enemy)
    {
        CRoom.TmpTextComponent1.text = $"<color=red>BUZZZZZZZZZ! \n{enemy.name} will be frozen for this turn and can't attack you!</color>";
        CRoom.TmpTextComponent1.font = CRoom.DisplayFont;
        CRoom.ShowEAText();
        StartCoroutine(InvokeHideEAText(CRoom, 3f));

        enemy.health /= 2;

        CRoom.TmpTextComponent1.text = $"<color=red>{enemy.name} hasn't recovered from the taser yet! Let's give the predator another heavy blow!</color>";
        CRoom.TmpTextComponent1.font = CRoom.DisplayFont;
        CRoom.ShowEAText();
        StartCoroutine(InvokeHideEAText(CRoom, 3f));
        foreach (DieRoller die in user.Dice)
        {
            if (die.numberOfSides == enemy.Dice[0].numberOfSides)
            {
                user.normalRoll(enemy);
                enemy.IGH.OnHealthChange(enemy.health, enemy.Dice[0].numberOfSides);
                user.EndOfTurn(enemy);
            }
        }
    }
}