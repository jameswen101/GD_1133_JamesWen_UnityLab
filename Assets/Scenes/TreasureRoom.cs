using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class TreasureRoom : Room
{
    public DeadSquirrel deadSquirrel;
    public Taser taser;
    public Shield shield;
    public MeatyBlade meatyBlade;
    public Fire fire;
    public Camouflage camouflage;
    public List<Item> items;
    public Item ActiveItem;

    private void Start()
    {
        items = new List<Item> { deadSquirrel, camouflage, shield, meatyBlade, fire, taser };
        hasItem = true;
        ActivateRandomItem();
        ActiveItem = ActivateRandomItem();
    }

    private void Update()
    {
        
    }

    public Item ActivateRandomItem() //use serializefield bools to check if each item is active in each room?
    {
        Random ItemRoulette = new();
        int RouletteNum = ItemRoulette.Next(0, 50);

        if (RouletteNum >= 0 && RouletteNum <= 8) 
        {
            Debug.Log($"Roulette number: {RouletteNum}");
            deadSquirrel.ItemObject.SetActive(true);
            if (deadSquirrel.ItemObject.activeSelf)
            {
                Debug.Log("Dead Squirrel is successfully activated!");
            }
        }
        else if (RouletteNum >= 9 && RouletteNum <= 17)
        {
            Debug.Log($"Roulette number: {RouletteNum}");
            camouflage.ItemObject.SetActive(true);
            if (camouflage.ItemObject.activeSelf)
            {
                Debug.Log("Camouflage is successfully activated!");
            }
        }
        else if (RouletteNum >= 18 && RouletteNum <= 26)
        {
            Debug.Log($"Roulette number: {RouletteNum}");
            shield.ItemObject.SetActive(true);
            if (shield.ItemObject.activeSelf)
            {
                Debug.Log("Shield is successfully activated!");
            }
        }
        else if (RouletteNum >= 27 && RouletteNum <= 35)
        {
            Debug.Log($"Roulette number: {RouletteNum}");
            meatyBlade.ItemObject.SetActive(true);
            if (meatyBlade.ItemObject.activeSelf)
            {
                Debug.Log("Meaty Blade is successfully activated!");
            }
        }
        else if (RouletteNum >= 36 && RouletteNum <= 44)
        {
            Debug.Log($"Roulette number: {RouletteNum}");
            fire.ItemObject.SetActive(true);
            if (fire.ItemObject.activeSelf)
            {
                Debug.Log("Fire is successfully activated!");
            }
        }
        else if (RouletteNum >= 45 && RouletteNum <= 49)
        {
            Debug.Log($"Roulette number: {RouletteNum}");
            taser.ItemObject.SetActive(true);
            if (taser.ItemObject.activeSelf)
            {
                Debug.Log("Taser is successfully activated!");
            }
        }
        return items[(int)RouletteNum / 9];
    }

    public void GiveItem()
    {
        //add 2D pic of item
        TmpTextComponent1.text = $"<color=red>Congratulations! You have received the item {ActiveItem.itemName}! \n{ActiveItem.description} \nGood luck fighting off the apex predators!</color>";
        ShowEAText();
        Invoke("HideEAText", 5f);
        user.ItemInventory.Add(ActiveItem);
        user.noItems = false;
    }

}
