using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
	public String itemName;
	public String description;
	public Rarity itemRarity;
	protected CombatRoom CRoom;
    protected TreasureRoom TRoom;
	public GameObject ItemObject;

	public abstract void UseItem(User user, Enemy enemy);

	public enum Rarity
	{
		Common = 0,
		Rare = 1
	}

    private void OnTriggerEnter(Collider other) //if user enters trigger
                                                
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("User has touched the item");
            // Deactivate the current item
            ItemObject.SetActive(false);
            TRoom.GiveItem();
        }
    }

    private void OnTriggerExit(Collider other) //if user leaves trigger
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("User has left the item");
            // Activate another random item
            TRoom.ActivateRandomItem();
            TRoom.ActiveItem = TRoom.ActivateRandomItem(); 
        }
    }

    protected virtual void Awake() // Initialization method for MonoBehaviour
	{
		
	}

	protected IEnumerator InvokeHideEAText(CombatRoom room, float delay)
	{
		yield return new WaitForSeconds(delay);
		room.HideEAText(); // Call the method on the CRoom instance
	}

	protected IEnumerator InvokeHideHealthText(CombatRoom room, float delay)
	{
		yield return new WaitForSeconds(delay);
		room.HideHealthText(); // Call the method on the CRoom instance
	}
}
