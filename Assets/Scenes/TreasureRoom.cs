using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class TreasureRoom : Room
{
    public DeadSquirrel deadSquirrel;
    public Taser taser;
    public Shield shield;
    public BloodyBlade bloodyBlade;
    public Fire fire;
    public Camouflage camouflage;
    public List<Item> items;


public TreasureRoom(int row, int col): base(row, col)
	{
        items = new List<Item> { fire, shield, camouflage, taser, deadSquirrel, bloodyBlade };
        this.row = row;
        this.col = col;
        this.name = $"room{row}-{col}";
        hasItem = true;
    }

    public void giveItem()
    {
        Random itemRandom = new Random();
        int itemNum = itemRandom.Next(0, items.Count);
        Debug.Log($"Congratulations! You have received the item {items[itemNum].itemName}! \n{items[itemNum].asciiArt} \n{items[itemNum].description} \nGood luck fighting off the apex predators!");
        user.ItemInventory.Add(items[itemNum]);
        user.noItems = false;
    }

}
