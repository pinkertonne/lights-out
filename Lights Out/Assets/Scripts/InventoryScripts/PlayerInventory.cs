using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // List of objects in the players inventory 
    public List<Item> playerInventory = new List<Item>();
    public ItemData gameItems; 

    // Start method that calls when the script first runs
    private void Start()
    {
        AddItem(0);
        RemoveItem(0);
    }

    // Adds an Item to the players inventory
    public void AddItem(int id)
    {
        Item itemAdded = gameItems.GetItem(id);
        playerInventory.Add(itemAdded);
        Debug.Log("Added Item " + id + ".\n"); // Here for testing
    }

    // Checks to see if an item is in the Player's Inventory
    public bool InInventory(int id)
    {
        return playerInventory.Exists(item => item.itemId == id);
    }

    // Deletes an item from the Player's Inventory
    public void RemoveItem(int id)
    {
        if (InInventory(id))
        {
            playerInventory.Remove(gameItems.GetItem(id));
            Debug.Log("Item " + id + " removed.\n");
        }
        else 
        {
            Debug.Log("Item " + id + " was not in the player's inventory.\n");
        }
    }
}
