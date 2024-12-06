using System;
using UnityEngine;

public class Eagle: Enemy
{
    //public GameObject EagleObject;
	public Eagle(String name): base(name)
	{
		this.name = name;
        row = 1;
        col = 1;
        position = new Vector2(1, 1);
    }
}
