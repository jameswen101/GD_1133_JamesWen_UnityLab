using System;
using UnityEngine;

public abstract class Item: MonoBehaviour
{
	public String itemName;
	public int row, column;
	public String description;
	public String asciiArt;

	public abstract void useItem(User user, Enemy enemy);

	public Item()
	{
	}
}
