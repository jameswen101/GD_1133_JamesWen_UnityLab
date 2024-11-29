using System;

public class Steak : Meat
{
    protected override void Awake()
    {
        base.Awake();
        name = "Steak";
        healthBoost = 20;
    }
}
