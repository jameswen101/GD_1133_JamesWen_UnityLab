using System;

public class Salmon : Meat
{
    public Salmon(String meatName, int healthBoost) : base(meatName, healthBoost)
    {
        this.meatName = meatName;
        this.healthBoost = healthBoost;
        description = $"Boost your health by {healthBoost} points";
        asciiArt = "          /\"*._         _\r\n      .-*'`    `*-.._.-'/\r\n    < * ))     ,       ( \r\n      `*-._`._(__.--*\"`.\\";
        //shows a fish
    }
}
