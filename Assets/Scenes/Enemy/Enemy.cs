using System;
using UnityEngine;

public class Enemy : Player
{
	public String asciiArt;
	protected User user;
	public Enemy(String name) : base(name)
	{
		this.name = name;
	}
	public void SetUser(User user)
	{
		this.user = user;
	}

	public void enemyIsDead()
	{
		if (health <= 0)
		{
			if (health < 0)
			{
				health = 0;
			}
			Debug.Log("                  _  /)\r\n                 mo / )\r\n                 |/)\\)\r\n                  /\\_\r\n                  \\__|=\r\n                 (    )\r\n                 __)(__\r\n           _____/      \\\\_____\r\n          |                  ||\r\n          |  _     ___   _   ||\r\n          | | \\     |   | \\  ||\r\n          | |  |    |   |  | ||\r\n          | |_/     |   |_/  ||\r\n          | | \\     |   |    ||\r\n          | |  \\    |   |    ||\r\n          | |   \\. _|_. | .  ||\r\n          |                  ||\r\n  *       | *   **    * **   |**      **\r\n   \\))ejm96/.,(//,,..,,\\||(,,.,\\\\,.((//\r\n");
			//Show picture of tombstone
			Debug.Log($"The {name}'s health is currently at {health} and is already dead. Keep fighting other apex predators before cooking them for dinner!");
		}
	}

	public void enemyApproaching()
	{
		Debug.Log(" _____ _   _ _____ __  ____   __                             \r\n| ____| \\ | | ____|  \\/  \\ \\ / /                             \r\n|  _| |  \\| |  _| | |\\/| |\\ V /                              \r\n| |___| |\\  | |___| |  | | | |                               \r\n|_____|_|_\\_|_____|_| _|_| |_|    ____ _   _ ___ _   _  ____ \r\n   / \\  |  _ \\|  _ \\ / _ \\  / \\  / ___| | | |_ _| \\ | |/ ___|\r\n  / _ \\ | |_) | |_) | | | |/ _ \\| |   | |_| || ||  \\| | |  _ \r\n / ___ \\|  __/|  _ <| |_| / ___ \\ |___|  _  || || |\\  | |_| |\r\n/_/   \\_\\_|   |_| \\_\\\\___/_/   \\_\\____|_| |_|___|_| \\_|\\____|");
		//ENEMY APPROACHING
	}

}
