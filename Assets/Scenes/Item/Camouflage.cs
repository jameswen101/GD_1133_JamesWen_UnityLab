using System;
using UnityEngine;

public class Camouflage: Item
{
	//Goal: wear camouflage hat (put it on user's head) -> add combat room brick material to user
	[SerializeField] private Material CamouflageMaterial;
	protected override void Awake()
	{
		base.Awake();
		description = "Use this item to hide from your enemy so they can't attack you. However, you can still attack them at half of the maximum damage.";
		itemRarity = Rarity.Common; // Initialize item rarity
	}

	public override void UseItem(User user, Enemy enemy)
	{
		Renderer userRenderer = user.GetComponent<Renderer>();
		if (userRenderer != null)
		{
			userRenderer.material = CamouflageMaterial;
			Debug.Log("Camouflage applied to the user!");
		}

		foreach (DieRoller die in user.Dice)
		{
			if (die.numberOfSides == enemy.Dice[0].numberOfSides)
			{
                die.Roll();
				if(die.roll > die.numberOfSides/2)
				{
					CRoom.TmpTextComponent1.text = $"<color=red>{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, divided by 2 because of {itemName}, with a total of {die.roll / 2}. Above average</color>";
					CRoom.ShowEAText();
					StartCoroutine(InvokeHideEAText(CRoom, 5f));
				}
                else if (die.roll == die.numberOfSides / 2)
                {
					CRoom.TmpTextComponent1.text = $"<color=red>{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, divided by 2 because of {itemName}, with a total of {die.roll / 2}. Average</color>";
					CRoom.ShowEAText();
					StartCoroutine(InvokeHideEAText(CRoom, 5f));
				}
				else
				{
					CRoom.TmpTextComponent1.text = $"<color=red>{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, divided by 2 because of {itemName}, with a total of {die.roll / 2}. Below average</color>";
					CRoom.ShowEAText();
					StartCoroutine(InvokeHideEAText(CRoom, 5f));
				}
				enemy.health -= (die.roll / 2);
				enemy.IGH.OnHealthChange(enemy.health, enemy.Dice[0].numberOfSides);
				user.EndOfTurn(enemy);
            }
		}

		user.StartCoroutine(RevertMaterial(user, userRenderer));
	}

	private System.Collections.IEnumerator RevertMaterial(User user, Renderer userRenderer)
	{
		yield return new WaitForSeconds(10f); // Example duration for camouflage
		userRenderer.material = user.DefaultMaterial; // Revert to the original material
		Debug.Log("Camouflage effect ended.");
	}

}
