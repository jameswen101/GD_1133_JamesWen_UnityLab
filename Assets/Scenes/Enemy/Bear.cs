using System;
using UnityEngine;

public class Bear : Enemy
{
    public Bear(String name) : base(name)
    {
        this.name = name;
        row = 4;
        col = 4;
        asciiArt = "    :\"'._..---.._.'\";\r\n    `.             .'\r\n    .'    ^   ^    `.\r\n   :      a   a      :                 __....._\r\n   :     _.-0-._     :---'\"\"'\"-....--'\"        '.\r\n    :  .'   :   `.  :                          `,`.\r\n     `.: '--'--' :.'                             ; ;\r\n      : `._`-'_.'                                ;.'\r\n      `.   '\"'                                   ;\r\n       `.               '                        ;\r\n        `.     `        :           `            ;\r\n         .`.    ;       ;           :           ;\r\n       .'    `-.'      ;            :          ;`.\r\n   __.'      .'      .'              :        ;   `.\r\n .'      __.'      .'`--..__      _._.'      ;      ;\r\n `......'        .'         `'\"\"'`.'        ;......-'\r\njgs    `.......-'                 `........'";
        //show ASCII art of the bear
        position = new Vector2(4, 4);
    }
}
