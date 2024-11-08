using System;
using UnityEngine;

public class Meat: MonoBehaviour
{
    public String meatName;
    public int row, column;
    public int healthBoost;
    public String description;
    public String asciiArt;
    public Meat(String meatName, int healthBoost)
    {
        this.meatName = meatName;
        this.healthBoost = healthBoost;
    }
}
