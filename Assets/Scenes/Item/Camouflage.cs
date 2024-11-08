﻿using System;
using UnityEngine;

public class Camouflage: Item
{
	public Camouflage()
    {
		description = "Use this item to hide from your enemy so they can't attack you. However, you can still attack them at half of the maximum damage.";
		asciiArt = "++@%%%%%%%%%%@-:########**#*########*++++####+::::-=--+%%%%%*#####%%%%%%%%%%%*++++++=::-++++++++++++\r\n++++*%::+%%%%%+:+####*#%%%%%%%%###########*-:::::*######**++++#####%%%%%%%%%%++++=:::::-++++++++===+\r\n+=+#%%:::=%%%%-:::=::+%%%%%%%%%%%%%%%+-+####*+==*######*++++++*#####%%%%%%%%#++-::::=+++++++**######\r\n::#%%%::::::::::::::=%%%%%%%%%%%%%%%%-::=#############*=++++++++*#####%%%%%*++=:::::=+++++#########%\r\n:::::::::::::::::::+%%%%%%%%%=:::::::::-######+==*+-==++++++++++++++*######+++-::-=++++++######+#%%#\r\n#:::::+#%%%%%%%%%%%%%%%%%%%#=::::::::::*#####++++-:::=++++++=++++++++++######:==-=++++*###*=+++++%%+\r\n#:::+%%%%%%%%%%%%%%%%*=--:::::::::::::::::::---::::::++=*%%*%%%+++++++++##*##%%+%%+++++*#*+++++++%%%\r\n::::*%%%%%+-#%%%%@::::::::::::::::::::::::::::::::::+==%%%%%%@#+++++++++#%%%%%%%%=+++++++++++++=%%%%\r\n***-:::::::::+*=:::::::::::::::::::::::::::::::::::::-=##*:=+++++++++++#%%%%%%%%+++++++++++++++=%%%%\r\n%%%%=:::::=#*+==-:-#%%%%%%-::::::-+**#*-::::::::++-::::::::######**++*#%%%%*==+++++++++++++++++++%%%\r\n%%%%+:::::=#######%%%%%%%-::::::=+*##-::::::-=*++++=::::::*###+-:::::*%%%%%#=+++++=-==+****#****###%\r\n:::::::::::*#####%%%%%%#:::::::::+++=::::=#####*#++++=::::*=:::::+%%%%%%%%%%#=-:::::::-############=\r\n:::::::+%%%%%%%%%%%##*-:::::::::++++++*##******+==+++++-::::::::::-*#%%-:::::::::::::*############=:\r\n::::::-%%%%%%%%%%@:::::::::::-=+=-=++=*#++++++:::-+++++#*:::::::::::::::::::::::::::::-*#########-::\r\n:-+*+-:::::::::::::::::*######*:::::::::----:::::-==*#####*:::::+++::::::::::-+*##=:-##*#######*::::\r\n%%%%%%%%%=:---:::=%=:::*******+:::::::::::--+#%%%%%%%#########*+++++:::::-#*######*:::+###*==+*:::-#\r\n%%%%%%#*######+=%%%#-::=+-::=++++===-::=%%%%%%%%%%%%%%###-::=+++++++=:::*#####-::::::::*#++++++-%%%%\r\n%%%%######%%%%%%####+:::::::=++++++=::#%%%%%%%%%##########*-::::-+++++*###++++::::::::=+++++++++%%%%\r\n%%%*##***#%%%#######*:::::::++++++:::::%%%%%%%%%#############=:::::+++###++++++-:::-++++++++++++#%%%\r\n%###*%%%%%*::::-***+::::-=+++++++-::::=#%%*##%#*###############:::::=++++++++++-::+++++++++++++++%%%\r\n%%%%%%%%%%*:::::::::::-++++++++++=====#%%#######*+++++++#######-::::-*#%%*++++-:::::::::-=+++++++%%%\r\n%%%%%%%%%%%%%%%%:::::-+++++++++++=++%%%%%#####+++++++++---+####-::-%%%%%%+++=::::::::::::-####*++%%%\r\n%%%%%%###%%%%#*#++++++++++++++++++*%%%%%%*###*++++++==::::::::::::-%%%#*+++++::==:::::::=######=+%%%\r\n%%#*########%%%%%%%%%%%%%%*+++++++++=+=*######*+++=:::::::::::::::::::**+++++++=+==-::::*####*++%%%%\r\n%##########%%%%%%%%%%%%%%%%%+++++++==-:::-=######=::::::::::::::::::=*#*+++++=%%%%%%%::=###*+=#%%%%%\r\n###########%%%%%%%+++++*%%%%=+++#*##+::::::::-=::::*%%%%%-::::::-*#####+++=-:%%%%%%%+::-####=%%%%%%%\r\n####*+=+++++%%%%=+++++++++++++++####*::::::::::::*%%%%%%%:::-+#****+=+-:::::-%%%%#:::::::+*+:::-*###\r\n##*++++++++++%%%*++++++++++++++++####-::::::::*##%%%#*##**#*+++++++++:::-+*%%%%%-:::::::::::::::::-#\r\n:::-=++++++++%%%%%+++++++++++=#%%%%%=::::::::=############++--++++++=:-%%%%%%%%#:::::::::::::::::::*\r\n::::-+++++##*%%%%%++++++++++=%%%%%%%@*:::::::+####*#######+==:--:-++=:*%%%%@%#::::::::::::::::::-##+\r\n::::=+++*##%%%%%%%#*++++++++++#%%%%+::::::::-+++++*####**###*:::-+++=:-%%%-::::::::::::--=+++#####-:\r\n::+#####%%%%%%%%%####+++==-=++++%%%#:=+++++++++++=+*##=:::::::+###++=::::::::::::::::=++++++####*:::\r\n::-===%%%%%%%#*#####+:::::::#%%%@@#-:::::-----::::+#######=:-####*=++:::::::**#####-::-+#*#*#%%%%%%+\r\n::::::%%%%%%#######=::::::::::::::::::::::::::::=++++++++=*#####*=+++=::::-########-::::::#%%%%%%%%-\r\n:::::::*%%#*###*+=+++++=*::::::::::::::::-:-=+++++++++++=++##**+++++++=:::=######*:::::::*%%%%%%%+::\r\n:::::-+*######++++++++++-::::+%%%%-::::::++++++++++++*###*=--=++++++++++=+##*:::::::::::::*%#*=:::::\r\n:::*#########++++++++++++=*%%%#-:::::::=+++++++++++#####-::::::-++++++++####=:::::::::::::::::::::::\r\n:::-*########++++++++++#%%%%+-:::::::=+++*%+++++*#####*=::::::::=+++++++**#*::::::::::::::::::::::::\r\n:::::-*#######++++++++%%#++-:::===--++++++%%#######*++++:::::::-+++++++=::::::::::::::::::::::::-#-:\r\n:::::::-*#####+++++++----:::-*######+++++%%%%%%###+++++=:::::::=+++++++:::::::::-###::::::::::::-*#+\r\n:::::::::::*#*++++=#####################*%%%#####++++++=-%%%%%%%++++++++=::::::::-##:+@%@*::::#@%###\r\n+-----+#=::-%%*++++++++++###########%%%%%%%+::-++==+++-:-%%%%%%%*+++++++++-::::::::#%%%%%%%%%%%%%%##\r\n+**++==++--#%%%%%%++++++=########+::=---::::::::::::::::-%%#++++++++++++++:::::::#%%%%%%%%%####*####\r\n+::::--::*%%%%+-::==+===*######+::::::::::::::::::::::::+%%%%#++++++++++=::::::=%%%%*--%%%%*++++++*+\r\n++++++++=#%%:::-%%%####***###-:::::::-=+++++-:=+++-:#%%%%%%%%+++++++:::::::::::*%%%%+::-:++=++++++++\r\n+++++++++%%%%%%%%%#=*#*-:::::::::::-*++=++++++++=::%%%%%%%%+++++++++-###+:::=+=-%%%%#::::+++++====--\r\n+++++++%%%%%==**+++++*###*++*##*++%%%%%%%+++++=:::::-*%@%%#=+++++++*#####*:-#######+-::=++=-::::::::\r\n*++++*%%+++++=####=+++++++=++++++%%%%%%%%%%-:::::::::::::=+++++=+**#######-:-#####*=+++++-::::::::::\r\n##*++**++++++=*##+++++++++++++++=%%%%%%%%%%=::::::::::::-++++*##########*-::::+###++++++++---=*##:::\r\n########*++++++#*+++++++=-::#*+*%%%%%%%%%%-::::::-----::+++=*##########-:::::::-##++++++++*#######*#\r\n#########=++++++##+-=-:#%%%%%%%%%%%%%::::::::-=+++++++==++++############*:::::::+#*+++++++#######**#\r\n########*+++++++##::::*%%%%@%%%%%%%%%:::::::=++=++:::::+++++###############+:::*##==+++++++***++++++\r\n##**+-::=+++++++=::::::::::::#%%*::::::::-=++=*=-::::::=++*##%%%#############%%%%%%%%++++++++++++++*\r\n+==:::::=++++++-:::::::::::::+%%*:::::::-++++:-####*+***++++#%%%%%%#######*#%%%%%%%%%%*+++++++++++++\r\n*=++=::::-=+=-:::::::::+#+::-+*#*::::::::::::-####+::::::::::=%%%%%%%%%%%%%%%%%%%%%%%%#+++++++++++++";
		//show picture of camouflage
	}

	public override void useItem(User user, Enemy enemy)
	{
		foreach (DieRoller die in user.Dice)
		{
			if (die.numberOfSides == enemy.Dice[0].numberOfSides)
			{
                Console.WriteLine("__   _____  _   _ ____    _____ _   _ ____  _   _ \r\n\\ \\ / / _ \\| | | |  _ \\  |_   _| | | |  _ \\| \\ | |\r\n \\ V / | | | | | | |_) |   | | | | | | |_) |  \\| |\r\n  | || |_| | |_| |  _ <    | | | |_| |  _ <| |\\  |\r\n  |_| \\___/ \\___/|_| \\_\\   |_|  \\___/|_| \\_\\_| \\_|");
                //YOUR TURN
                die.Roll();
				if(die.roll > die.numberOfSides/2)
				{
					Debug.Log($"{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, divided by 2 because of {itemName}, with a total of {die.roll/2}. Above average");
				}
                else if (die.roll == die.numberOfSides / 2)
                {
					Debug.Log($"{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, divided by 2 because of {itemName}, with a total of {die.roll / 2}. Average");
                }
				else
				{
					Debug.Log($"{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, divided by 2 because of {itemName}, with a total of {die.roll / 2}. Below average");
                }
				enemy.health -= (die.roll / 2);
				Console.WriteLine($"{user.health} vs {enemy.health}");
            }
		}
	}
}