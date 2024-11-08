﻿using System;
using UnityEngine;

public class BloodyBlade : Item

{
    public BloodyBlade()
    {
        description = "Use it to increase your die roll by 3 in most enemies, and increase your roll by 5 when fighting against the bear.";
        asciiArt = "    .......   .......   .......   .......   .......   .......   .......   .......   ................\r\n    .......   .......   .......   .......   .......   .......   .......   .......   ................\r\n.......................................................................................:+-..=:......\r\n....................................................................................-++++#:..--.....\r\n......   ........  .......   ........  .......   ........  .......   ........  ..:+++++++*#-.:=-.   \r\n...............................................................................-+++++***+###=::*....\r\n    .......   .......   .......   .......   .......   .......   .......  ...:=*+=+****+*#####--=+...\r\n...........................................................................=*==+******###%%%#+--*...\r\n.........................................................................+*-=+***+-:=##%%%%%#+++#...\r\n......   ........  ......... ........  ......... ........  ............=*-==*#*+**-:-#%%%%%##++=+...\r\n.....................................................................-*===*#*+*###%%%%%%%%%#*+=+....\r\n...................................................................:++-=+##***#%%%%%%%%%%#*++=-.....\r\n    .......   .......   .......   .......   .......   .......   ..=*===*#***#%%%%%%%%#**+=-:........\r\n.................................................................+=-=*##**#%%%%%%%#*+=-.............\r\n......   .......   .......   .......   .......   .......   ....-*-==###*#%%%%%%##+:.............    \r\n......   .......   .......   .......   .......   .......   ...+=-=*##*##%%%%%##:................    \r\n............................................................:+--+##**#%%%%%%*-......................\r\n    .......   .......   .......   .......   .......   .....=+-=*##*##%%%%%*-.....   .......   ......\r\n.........................................................:+==+****##%%%%#=..........................\r\n........................................................-*=+#*:.:+#%%%#*:...........................\r\n......   .......   .......   .......   .......   .....:*=+**++*+*#%%%#=.....   .......   .......    \r\n.....................................................=###########%%##:..............................\r\n...................................................:+::#########%%##:...............................\r\n    .......   .......   .......   .......   ......==....+%%###%%%#*:... . .......   .......   ......\r\n................................................-+*=....:=#%%%%%%#..................................\r\n......   ........  .......   ........  ........==--+*-:::::+%%%%#:...............................   \r\n.............................................:+:--::-#*:::::-#%%*...................................\r\n............................................+--=:-=::=*#*-::--=##...................................\r\n    .......   .......   .......   ........-=--=+=---:+*-+*#+----++:....   .......   .......   ......\r\n........................................:=---++-:::-=---:-=*#*+=+++=-...............................\r\n.......................................-=:-=+=::::-:...:-=--=*****++++-:............................\r\n......    ......   .......    .......:+::-++-:::::...:::..:=*:...:+++*++++=:.  .......    ......    \r\n....................................=-::-+--::.-.....=+---..+:........-+*##:........................\r\n..................................:+::.==-:::-:..:::+++*#*#=........................................\r\n    .......   .......   .........=-::=+-:::::..-+##--=*##*-............   .......   .......   ......\r\n...............................:-::-+=-:::::..:==---*##%*...........................................\r\n......   ........  ....... ...--:-++--::::..:--:=**####*...........  ........  .......   ........   \r\n............................:=.:=+=-:::-...-=::=*#%#%%*.............................................\r\n...........................=::-*==-::-:...:**#####+#%*..............................................\r\n    .......   .......  ..:-::+==-:::=.:*##*#*####=:#*.::.....   .......   .......   .......   ......\r\n........................-::-+--::.=:..-+**######:.*#..=.............................................\r\n......................:-::==::::--::.+**#####%+..+#:.--.............................................\r\n......    ......  ...-::-+-::::-::::=#*#####%=..=#-...............   .......   .......    ......    \r\n....................-.:-=::::-:-::+#######%#*..=%+..................................................\r\n    .......   ....::::--::-=--+########*##+...-##... ........   .......   .......   .......   ......\r\n    .......  ....-:::::==-:-:+#####**%=##:...:#%=..  ........   .......   .................   ......\r\n...............:-:::=-:....:+*##*++#=:*#::=..+#%....................................................\r\n......   .....=:---:..:--=*###+==*=.-##:.-:..#%*..................   ........  ..................   \r\n............:=:--..:-+**#***+==+=:.=*+......=#%=....................................................\r\n...........-+-:.:-=***##+====+=....:........###:....................................................\r\n    ......+=:.:+**=========+-..............-*#:....  ........   .......   .......   .......   ......\r\n........:*:.:=***#**++*##=:....:....................................................................\r\n.......==:-+****#######=:...:::-....................................................................\r\n......+++****##**###+-....:*##-.....   .......   .......   .......    ......   .......    ......    \r\n....:++++*****#**+:........==:......................................................................\r\n...-===+****+-...........................   .......   .......   .......   .......   .......   ......\r\n....................................................................................................\r\n....................................................................................................\r\n................   .......   .......   .......   ........  .......   ........  .......   ........   \r\n......   .......   .......   .......   .......   .......   .......   .......   .......   .......    ";
        //show picture of bloody blade
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
                if (enemy.name == "Bear")
                {
                    if (die.roll > die.numberOfSides / 2)
                    {
                        Debug.Log($"{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, plus 5 from the {itemName}, with a total of {die.roll + 5}. Above average");
                    }
                    else if (die.roll == die.numberOfSides / 2)
                    {
                        Debug.Log($"{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, plus 5 from the {itemName}, with a total of {die.roll + 5}. Average");
                    }
                    else
                    {
                        Debug.Log($"{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll}, plus 5 from the {itemName} , with a total of {die.roll + 5}. Below average");
                    }
                    enemy.health -= (die.roll + 5);
                }
                else {
                    if (die.roll > die.numberOfSides / 2)
                    {
                        Debug.Log($"{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll} , plus 3 from the {itemName}, with a total of {die.roll + 3}. Above average");
                    }
                    else if (die.roll == die.numberOfSides / 2)
                    {
                        Debug.Log($"{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll} , plus 3 from the {itemName}, with a total of  {die.roll + 3}. Average");
                    }
                    else
                    {
                        Debug.Log($"{user.name} rolled a {die.numberOfSides} sided die for a result of {die.roll} , plus 3 from the {itemName}, with a total of  {die.roll + 3}. Below average");
                    }
                    enemy.health -= (die.roll + 3);
                }
                Console.WriteLine(" _____ _   _ _____ __  ____   ___ ____    _____ _   _ ____  _   _ \r\n| ____| \\ | | ____|  \\/  \\ \\ / ( ) ___|  |_   _| | | |  _ \\| \\ | |\r\n|  _| |  \\| |  _| | |\\/| |\\ V /|/\\___ \\    | | | | | | |_) |  \\| |\r\n| |___| |\\  | |___| |  | | | |    ___) |   | | | |_| |  _ <| |\\  |\r\n|_____|_| \\_|_____|_|  |_| |_|   |____/    |_|  \\___/|_| \\_\\_| \\_|");
                //ENEMY'S TURN
                enemy.Dice[0].Roll();
                if (enemy.Dice[0].roll > enemy.Dice[0].numberOfSides / 2)
                {
                    Debug.Log($"{enemy.name} rolled a {enemy.Dice[0].numberOfSides} sided die for a result of {enemy.Dice[0].roll}. Above average");
                }
                else if (die.roll == die.numberOfSides / 2)
                {
                    Debug.Log($"{enemy.name} rolled a {enemy.Dice[0].numberOfSides} sided die for a result of {enemy.Dice[0].roll}. Average");
                }
                else
                {
                    Debug.Log($"{enemy.name} rolled a {enemy.Dice[0].numberOfSides} sided die for a result of {enemy.Dice[0].roll}. Below average");
                }
                user.health -= enemy.Dice[0].roll;
                Console.WriteLine($"{user.health} vs {enemy.health}");
            }
        }
    }
}
