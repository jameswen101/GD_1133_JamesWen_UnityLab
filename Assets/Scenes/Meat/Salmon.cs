using System;

public class Cod : Meat
{
    protected override void Awake()
    {
        base.Awake();
        name = "Cod";
        healthBoost = 15;
    }
}
