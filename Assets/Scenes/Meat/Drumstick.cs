using System;

public class Drumstick : Meat
{

    protected override void Awake()
    {
        base.Awake();
        name = "Drumstick";
        healthBoost = 5;
    }
}

