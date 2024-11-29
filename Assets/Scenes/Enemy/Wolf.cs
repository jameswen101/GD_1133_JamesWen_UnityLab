using System;
using UnityEngine;

public class Wolf : Enemy
{
    public Wolf(String name) : base(name)
    {
        this.name = name;
        row = 3;
        col = 3;
        position = new Vector2(3, 3);
    }
}
