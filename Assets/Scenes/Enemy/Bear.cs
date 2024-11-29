using System;
using UnityEngine;

public class Bear : Enemy
{
    public Bear(String name) : base(name)
    {
        this.name = name;
        row = 4;
        col = 4;
        position = new Vector2(4, 4);
    }
}
