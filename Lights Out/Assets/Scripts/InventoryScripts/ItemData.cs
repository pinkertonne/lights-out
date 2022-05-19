using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A public class for managing the state of objects in the game
public class ItemData : MonoBehaviour
{
    //A list of the different items 
    public List<Item> playerItems;

    // runs when the game begins
    // initializes the items in the map
    private void Awake()
    {
        BuildDatabase();
    }

    // a data base of the items
    void BuildDatabase()
    {
        playerItems = new List<Item>(){};
        // Adds a new battery to the database
        for (int i = 0; i < 5; i++)
        {
            playerItems.Add(new Item(i, "battery"){});
        } 
        playerItems.Add(new Item(20, "matchbox"){});
        playerItems.Add(new Item(10, "candle"){});   
    }

    // Gets the item based on its ID
    public Item GetItem(int id)
    {
        return playerItems.Find(Item => Item.itemId == id);
    }
}
