using System;
using System.Collections.Generic;
using UnityEngine;

public class Alligator : Enemy
{
    public Alligator(String name) : base(name)
    {
        this.name = name;
        this.user = user;
        row = 2;
        col = 2;
        asciiArt = "           _  _\r\n             / \\/ \\-._   _.-'^'^^'^^'^^\"^^'-.\r\n    .OO.----'\\o/\\o/   `-'                /^  ^^-._\r\n   (    `                 \\             |    _    ^^-._\r\n    VvvvvvvVvv`___...)_/  /_/_/_/_/_/_/_/\\  (__________^^-.\r\njgs  `^^^^^^^^`       /  /                >  >        _`)  )\r\n                     (((`                (((`        `'--'^";
        //show ASCII art of the alligator
        position = new Vector2(2, 2);
        //public List<DieRoller> Dice = new List<DieRoller> {user.Dice[1]};
        //health = Dice[0].numberOfSides * 2;
    }
}
