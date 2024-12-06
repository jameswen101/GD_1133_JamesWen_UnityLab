using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DiningRoom : Room
{
    Ham Ham;
    Steak Steak;
    Drumstick Drumstick;
    Cod Cod;
    public List<Meat> meats;
    public Meat ActiveMeat;

    private void Start()
    {
        meats = new List<Meat> {Drumstick, Ham, Cod, Steak};
        hasMeat = true;
        ActivateRandomMeat();
        ActiveMeat = ActivateRandomMeat();
    }

    public void GiveMeat()
    {
        TmpTextComponent1.text = $"<color=red>Congratulations! You have received the meat {ActiveMeat.meatName}! \nGood luck fighting off the apex predators!</color>";
        ShowEAText();
        //ShowIcon();
        Invoke(nameof(HideEAText), 5f);
        //HideIcon();
        user.health += ActiveMeat.healthBoost;
        TmpTextComponent2.text = $"<color=red>Your health is now {user.health}.</color>";
        ShowHealthText();
        //health may be more than the initial amount
        Invoke(nameof(HideHealthText), 2f);
    }

    public Meat ActivateRandomMeat()
    {
        Random meatRandom = new Random();
        int meatNum = meatRandom.Next(0, meats.Count);
        meats[meatNum].MeatObject.SetActive(true);
        return meats[meatNum];
    }
    /*
    private void ShowIcon()
    {
        ActivateRandomMeat().MeatIcon.SetActive(true);
    }

    private void HideIcon()
    {
        ActivateRandomMeat().MeatIcon.SetActive(false);
    }
    */
}
