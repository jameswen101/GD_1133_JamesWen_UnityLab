using System;
using UnityEngine;

public class DeadSquirrel : Item
{
    public DeadSquirrel()
    {
        description = "Use this to skip an attack turn- the enemy will eat the dead squirrel for that turn and won't attack you.";
        asciiArt = "        />> \r\n __   .' '}\r\n{_ \\.'  <<\r\n  \\(  )_/``\r\n   ``---`` "; //shows a squirrel
    }

    public override void useItem(User user, Enemy enemy)
    {
        Debug.Log($"No rolls will happen this turn- the {enemy.name} is happily devouring their dead squirrel and you will be safe for now. Good luck hunting other apex predators!");
    }
}
