using System;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public List<DieRoller> Dice = new List<DieRoller>();
    public int health = 0, row = 0, col = 0;
    public Vector2 position;
    public String name;
    [HideInInspector]
    public InGameHud IGH;

    public GameObject HealthBarBackground;
    public GameObject HealthBarCurrent;

    public Player(String name) //constructor
    {
        this.name = name;
    }
}
