using System;
using System.Collections.Generic;
using UnityEngine;

public class Alligator : Enemy
{
    public Alligator(String name) : base(name)
    {
        this.name = name;
        row = 2;
        col = 2;
        position = new Vector2(2, 2);
        //public List<DieRoller> Dice = new List<DieRoller> {user.Dice[1]};
        //health = Dice[0].numberOfSides * 2;
    }
}
