using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DiningRoom : Room
{
    PorkRibs porkRibs;
    Steak steak;
    Drumstick drumstick;
    Salmon salmon;
    public List<Meat> meats;

    public DiningRoom(int row, int col) : base(row, col)
    {
        meats = new List<Meat> {porkRibs, steak,  drumstick, salmon};
        this.row = row;
        this.col = col;
        this.name = $"room{row}-{col}";
        hasMeat = true;
    }

    public void giveMeat()
    {
        Random meatRandom = new Random();
        int meatNum = meatRandom.Next(0, meats.Count);
        Debug.Log($"Congratulations! You have received the item {meats[meatNum].meatName}! \n {meats[meatNum].asciiArt} \n{meats[meatNum].description} \nGood luck fighting off the apex predators!");
        user.health += meats[meatNum].healthBoost;
        Debug.Log($"Your health is now {user.health}."); //health may be more than the initial amount
    }

}
