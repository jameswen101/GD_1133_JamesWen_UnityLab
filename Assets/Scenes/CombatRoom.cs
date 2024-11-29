using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatRoom : Room
{
    readonly Eagle Eagle; //make them all game objects?
    readonly Alligator Alligator; //why make them readonly?
    readonly Wolf Wolf;
    readonly Bear Bear;
    readonly User user;
    public Enemy ActiveEnemy;
    public GameObject Tombstone; //inactive by default, until after the enemy in the room dies
    private PlayerMovement PlayerMove;

    [HideInInspector]
    public List<Enemy> enemies;

    private void Start()
	{
        enemies = new List<Enemy> { Eagle, Alligator, Wolf, Bear }; //must be in a function?

        hasEnemy = true;
    }

    public void AddDiceHealth() //call this in GM
    {
        for (int c = 0; c < enemies.Count; c++)
        {
            enemies[c].Dice.Add(user.Dice[c]);
            user.health += user.Dice[c].numberOfSides;
            enemies[c].health += enemies[c].Dice[0].numberOfSides * 2;
        }
    }

    public void ShowEnemy()
    {
        bool IsDead = Tombstone.activeSelf;
        foreach (Enemy enemy in enemies)
        {
            bool IsAlive = enemy.PredatorObject.activeSelf;
            if (PlayerMove.currentCRoom.ActiveEnemy == enemy) //change to collider
            {
                if (enemy.health > 0)
                {
                    TmpTextComponent1.text = "<color=red>ENEMY APPROACHING</color>"; //initializing the text
                    ShowEAText();
                    TmpTextComponent1.font = DisplayFont;
                   
                    Invoke("HideEAText", 2f);
                    enemy.PredatorObject.SetActive(true);
                    IsAlive = true;
                    if (IsAlive) {
                    Debug.Log($"Enemy number in room: {enemy.row - 1}");
                    }
                    TmpTextComponent2.text = $"<color=red>Enemy's health: {enemy.health}</color>";
                    ShowHealthText();
                    user.exchangeAttack(enemy);
                    Invoke("HideHealthText", 2f);
                }
                if (enemy.health <= 0)
                {
                    EnemyIsDead(enemy);
                }
            }
        }
    }

    public void EnemyIsDead(Enemy enemy)
    {
        if (enemy.health <= 0)
        {
            if (enemy.health < 0)
            {
                enemy.health = 0;
            }
            enemy.PredatorObject.SetActive(false);
            TmpTextComponent1.text = $"<color=red>The {enemy.name}'s health is currently at {enemy.health} and is already dead. Keep fighting other apex predators before cooking them for dinner!</color>";
            ShowEAText();
            Invoke("HideEAText", 3f);
            Tombstone.SetActive(true); //make tombstone inactive to start?
                                       //make tombstone active                        
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowEnemy();
        }
        if (ActiveEnemy.health <= 0)
        {
            TmpTextComponent1.text = "<color=red>ENEMY IS DEAD</color>";
            ShowEAText();
            TmpTextComponent1.font = DisplayFont;
            Invoke("HideEAText", 2f);
        }
    }

    public Enemy ActivateEnemy()
    {
        switch (row)
        {
            case 1:
                Eagle.PredatorObject.SetActive(true);
                ActiveEnemy = Eagle;
                break;
            case 2:
                Alligator.PredatorObject.SetActive(true);
                ActiveEnemy = Alligator;
                break;
            case 3:
                Wolf.PredatorObject.SetActive(true);
                ActiveEnemy = Wolf;
                break;
            case 4:
                Bear.PredatorObject.SetActive(true);
                ActiveEnemy = Bear;
                break;
        }
        return ActiveEnemy;
    }

}
