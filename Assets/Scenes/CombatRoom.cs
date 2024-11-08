using System;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoom: Room
{
    Eagle eagle; //declaring player objects for cpu
    Alligator alligator; //declaring player objects for cpu
    Wolf wolf; //declaring player objects for cpu
    Bear bear; //declaring player objects for cpu

    public List<Enemy> enemies;

    public CombatRoom(int row, int col): base(row, col)
	{
        enemies = new List<Enemy> { eagle, alligator, wolf, bear };
        this.row = row;
        this.col = col;
        this.name = $"room{row}-{col}";
        hasEnemy = true;

    }

    public void addDiceHealth()
    {
        for (int c = 0; c < enemies.Count; c++)
        {
            enemies[c].Dice.Add(user.Dice[c]);
            user.health += user.Dice[c].numberOfSides;
            enemies[c].health += enemies[c].Dice[0].numberOfSides * 2;
        }
    }

    public void showEnemy()
    {
        foreach (Enemy enemy in enemies)
        {
            if (user.row == enemy.row && user.col == enemy.col)
            {
                if (enemy.health > 0)
                {
                    enemy.enemyApproaching(); //show enemy approaching message
                    Debug.Log(enemy.asciiArt); //show ASCII art of the enemy
                    Debug.Log($"Enemy's health: {enemy.health}");
                    user.exchangeAttack(enemy);
                }
                if (enemy.health <= 0)
                {
                    enemy.enemyIsDead();
                }
            }
        }
    }
}
