using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour //the big class for the item inventory
{
    [SerializeField] private Transform InventoryContentParent;
    [SerializeField] private InventoryItem ItemExamplePrefab;

    List<Item> fakeInventoryForTesting = new();
    List<InventoryItem> inventoryItemInstances = new();

    private void Awake()
    {
        fakeInventoryForTesting.Add(gameObject.AddComponent<Item>());
    }

    private void OnEnable() //function for when user gets an item
        //basically the same as GetItem in TreasureRoom
    {
        foreach(Item item in fakeInventoryForTesting)
        {
            var inventoryItem = Instantiate(ItemExamplePrefab, InventoryContentParent);
            //inventoryItem.Start(item);
            inventoryItemInstances.Add(inventoryItem);
        }
    }

    private void OnDisable() //function for after user uses an item
    {
        foreach(InventoryItem item in inventoryItemInstances)
        {
            Destroy(item.gameObject);
        }
        inventoryItemInstances.Clear();
    }

    public void ButtonContinue()
    {
        //unpause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //continue and quit buttons disappear
            //pause panel disappears
            //game resumes
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
