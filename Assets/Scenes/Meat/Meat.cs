using System;
using UnityEngine;
using UnityEngine.UI;

public class Meat: MonoBehaviour
{
    public String meatName;
    public int healthBoost;
	public GameObject MeatObject;
	//public GameObject MeatIcon;
    protected DiningRoom DRoom;

    private void OnTriggerEnter(Collider other) //if user enters trigger
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("User has touched the item");
            // Deactivate the current item
            MeatObject.SetActive(false);
            DRoom.GiveMeat();
        }
    }

    private void OnTriggerExit(Collider other) //if user leaves trigger
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("User has left the item");
            // Activate another random item
            DRoom.ActivateRandomMeat();
            DRoom.ActiveMeat = DRoom.ActivateRandomMeat();
        }
    }

    //declare a GameObject here for the 3D object that's activated (itself) at the start of the game
    //Add a function where the object becomes inactive when clicked/user walks through it
    //After the user walks away, the object becomes active
    protected virtual void Awake() // Initialization method for MonoBehaviour
	{

	}
}
