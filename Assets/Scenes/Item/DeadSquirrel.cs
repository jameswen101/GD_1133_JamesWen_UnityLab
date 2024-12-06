using System;
using UnityEngine;

public class DeadSquirrel : Item
{
    protected override void Awake()
    {
        base.Awake();
        description = "Use this to skip an attack turn- the enemy will eat the dead squirrel for that turn and won't attack you."; 
        itemRarity = Rarity.Common; // Initialize item rarity
    }

    public override void UseItem(User user, Enemy enemy)
    {
        CRoom.TmpTextComponent1.text = $"<color=red>No rolls will happen this turn- the {enemy.name} is happily devouring their dead squirrel and you will be safe for now. Good luck hunting other apex predators!</color>";
        CRoom.TmpTextComponent1.font = CRoom.DisplayFont;
        CRoom.ShowEAText();
        StartCoroutine(InvokeHideEAText(CRoom, 3f));
    }
}
