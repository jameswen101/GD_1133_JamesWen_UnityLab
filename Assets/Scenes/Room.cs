using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = System.Random;

public class Room: MonoBehaviour
{
	public bool hasItem, hasMeat, hasEnemy = false;
    readonly MapMgr MapMgr;
	public int row, col;
    [SerializeField] 
    private GameObject NorthDoorway, EastDoorway, SouthDoorway, WestDoorway;
    [HideInInspector]
    public Room north, west, south, east;
    public GameObject NWall, WWall, SWall, EWall, Floor;
    [HideInInspector]
    public int roomNum;
    internal User user;
    TreasureRoom tRoom;
    DiningRoom dRoom;
    CombatRoom cRoom;
    public GameObject EACanvas;
    public GameObject EAPanel;
    public GameObject EAText;
    public GameObject HealthText;
    [HideInInspector]
    public TMP_Text TmpTextComponent1;
    [HideInInspector]
    public TMP_Text TmpTextComponent2;
    public TMP_FontAsset DisplayFont;

    private void Start()
	{
        roomNum = row * 5 + col;
        TmpTextComponent1 = EAText.GetComponent<TMP_Text>();
        TmpTextComponent2 = HealthText.GetComponent<TMP_Text>();
        EAText.SetActive(false);
    }

    public void OnRoomSearched() //function activated when a key is pressed
    {
            for (int i = 0; i < MapMgr.roomsInMap.Count; i++)
            {
                if (row == user.row && col == user.col) //change to collider
                {

                    if (MapMgr.roomsInMap[i].hasItem)
                    {
                        
                        TmpTextComponent2.text = $"<color=red>Current room coordinates: ({row}, {col}) \nTreasure room</color>";
                        ShowHealthText();
                        Invoke("HideHealthText", 5f);
                        tRoom.GiveItem();
                    }
                    else if (MapMgr.roomsInMap[i].hasMeat)
                    {
                        TmpTextComponent2.text = $"<color=red>Current room coordinates: ({row}, {col}) \nDining room</color>";
                        ShowHealthText();
                        Invoke("HideHealthText", 5f);
                        dRoom.GiveMeat();
                    }
                    else if (MapMgr.roomsInMap[i].hasEnemy)
                    {
                        TmpTextComponent2.text = $"<color=red>Current room coordinates: ({row}, {col}) \nCombat room</color>";
                        ShowHealthText();
                        Invoke("HideHealthText", 5f);
                        cRoom.ShowEnemy();
                    }
                    else
                    {
                        TmpTextComponent2.text = $"<color=red>Current room coordinates: ({row}, {col}) \nThis room is safe.</color>";
                        ShowHealthText();
                        Invoke("HideHealthText", 5f);
                    }
                }
            }
    }

    public void OnRoomExit() //activated via collider
    {
        ShowHealthText();
        TmpTextComponent2.text = $"<color=red>You are about to exit the current room.</color>";
        Invoke("HideHealthText", 3f);
    }

    public void OnRoomEntered() //why still not working?
    {
        ShowHealthText();
        TmpTextComponent2.text = $"<color=red>You have just entered this new room. \nLet's search this room for items and enemies!</color>";
        Invoke("HideHealthText", 3f);
    }

    public void ShowEAText()
    {
        EACanvas.SetActive(true);
        EAPanel.SetActive(true);
        EAText.SetActive(true);
    }

    public void HideEAText()
    {
        EAText.SetActive(false);
        EAPanel.SetActive(false);
        EACanvas.SetActive(false);
    }

    public void ShowHealthText()
    {
        EACanvas.SetActive(true);
        EAPanel.SetActive(true);
        HealthText.SetActive(true);
    }

    public void HideHealthText()
    {
        HealthText.SetActive(false);
        EAPanel.SetActive(false);
        EACanvas.SetActive(false);
    }

}
        