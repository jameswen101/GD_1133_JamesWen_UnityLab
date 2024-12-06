using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour //this class is for choosing items to use during combat room fights
    //have all 6 item icons run the same script
    //press i to activate the whole inventory screen, press i to deactivate it, but allow deactivation only after the item is used
{
    [SerializeField] private Button ItemButton;
    [SerializeField] private TextMeshProUGUI ItemName;
    [SerializeField] private TextMeshProUGUI QuantityText;
    private int ItemCount;
    private string IName;
    private User user;
    private PlayerMovement UserMove;
    private TreasureRoom TRoom;
    private CombatRoom CRoom;
    //in the main item inventory class, make a list of InventoryItems and 
    // Start is called before the first frame update
    private void Start()
    {
        IName = ItemName.text;
    }
    /*
    public void Setup(Item GameItem)
    {
        switch (GameItem.itemRarity)
        {
            case (Item.Rarity.Common):
                ItemButton.color = Color.white;
                break;
            case (Item.Rarity.Rare):
                ItemIcon.color = Color.blue;
                break;
        }
        ItemName.text = GameItem.itemName;
    }
    */
    // Update is called once per frame
    void Update()
    {
        foreach (Item item in user.ItemInventory)
        {
            if (item.name == IName)
            {
                ItemCount += 1;
            }
        }
        QuantityText.text = $"x+{ItemCount}";
    }

    public void WhenClicked()
    {
        if (UserMove.currentCRoom != null && ItemCount > 0)
        {
           ItemCount--;

            foreach (Item item in TRoom.items) //only happens once
            {
                if (ItemName.text.ToUpper() == item.name.ToUpper())
                {
                    item.UseItem(user, UserMove.currentCRoom.ActiveEnemy); // Use the item on the enemy in the room
                }
            }
        }
        else if (UserMove.currentRoom != null && ItemCount == 0)
        {
            Debug.Log("No items left!");
        }
        else
        {
            Debug.Log("You are not in a combat room!");
        }
    }

}
