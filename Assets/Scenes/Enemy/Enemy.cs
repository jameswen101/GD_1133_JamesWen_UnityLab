using System;
using System.Collections;
using UnityEngine;

public class Enemy : Player
{
	[HideInInspector]
	public String asciiArt;
	protected User user;
	public GameObject PredatorObject;
    private CombatRoom CRoom;

	public Enemy(String name) : base(name)
	{
		this.name = name;
	}
	public void SetUser(User user)
	{
		this.user = user;
	}

	public void NormalRoll()
	{
        CRoom.TmpTextComponent1.text = "<color=red>ENEMY'S TURN</color>";
        CRoom.TmpTextComponent1.font = CRoom.DisplayFont;
        CRoom.ShowEAText();
        Invoke("HideEAText", 2f);
        Dice[0].Roll();
        if (Dice[0].roll > Dice[0].numberOfSides / 2)
        {
            CRoom.TmpTextComponent1.text = $"<color=red>{name} rolled a {Dice[0].numberOfSides} sided die for a result of {Dice[0].roll}. Above average</color>";
            CRoom.ShowEAText();
            StartCoroutine(InvokeHideEAText(CRoom, 5f));
        }
        else if (Dice[0].roll == Dice[0].numberOfSides / 2)
        {
            CRoom.TmpTextComponent1.text = $"<color=red>{name} rolled a {Dice[0].numberOfSides} sided die for a result of {Dice[0].roll}. Average</color>";
            CRoom.ShowEAText();
            StartCoroutine(InvokeHideEAText(CRoom, 5f));
        }
        else
        {
            CRoom.TmpTextComponent1.text = $"<color=red>{name} rolled a {Dice[0].numberOfSides} sided die for a result of {Dice[0].roll}. Below average</color>";
            CRoom.ShowEAText();
            StartCoroutine(InvokeHideEAText(CRoom, 5f));
        }
        user.health -= Dice[0].roll; //show that in the health bar
        IGH.OnHealthChange(user.health, user.CalculateMaxHealth());
    }

    private IEnumerator InvokeHideEAText(CombatRoom room, float delay)
    {
        yield return new WaitForSeconds(delay);
        room.HideEAText(); // Call the method on the CRoom instance
    }

    private IEnumerator InvokeHideHealthText(CombatRoom room, float delay)
    {
        yield return new WaitForSeconds(delay);
        room.HideHealthText(); // Call the method on the CRoom instance
    }

}
