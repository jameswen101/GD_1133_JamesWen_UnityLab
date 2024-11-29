using System;

public class Ham: Meat
{
    protected override void Awake()
    {
        base.Awake();
        name = "Ham";
        healthBoost = 10;
    }
}
