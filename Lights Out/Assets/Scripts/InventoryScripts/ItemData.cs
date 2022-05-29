using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    A public class for managing the state of objects in the game
*/
public class ItemData : MonoBehaviour
{
    //A list of the different items 
    public List<Item> playerItems;

    // The different items 
    public Item item1;
    public Item item2;
    public Item item3;

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
        playerItems.Add(item1);
        playerItems.Add(item2);
        playerItems.Add(item3);

        
    }

    // Gets the item based on its ID
    public Item GetItem(int id)
    {
        return playerItems.Find(Item => Item.itemId == id);
    }
}
