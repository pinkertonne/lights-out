using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // public vars 
    public Stack<Item> batteryStack = new Stack<Item>();
    public Stack<Item> matchStack = new Stack<Item>();
    public ItemData gameItems; 
    public int batteryCount = 0;
    public int matchCount = 0;

    // Runs for every frame 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ShowInventory();
        }
    }

    // Adds an Item to the players inventory
    public void AddItem(int id)
    {
        Item itemAdded = gameItems.GetItem(id);
        //Debug.Log("Added Item " + id + ".\n"); // Here for testing

        if (id >= 0 && id < 20)
        {
            batteryStack.Push(itemAdded);
            batteryCount += 1; 
        }
        else 
        {
            matchStack.Push(itemAdded);
            matchCount += 1; 
        }
        ShowInventory();
    }

    // Deletes an item from the Player's Inventory
    public void RemoveItem(int id)
    {
        if ((id >= 0 && id < 20) && batteryStack.Count > 0)
        {
            batteryStack.Pop();
        }
        else if (matchStack.Count > 0)
        {
            matchStack.Pop();
        }
        ShowInventory();
    }

    // Displays the current inventory of the Player 
    public void ShowInventory()
    {
        batteryCount = 0;
        matchCount = 0; 

        foreach (Item i in batteryStack)
        {
            batteryCount += 1;
        }

        foreach (Item i in matchStack)
        {
            matchCount += 1; 
        }

        Debug.Log("Battery Count:  " + batteryCount);
        Debug.Log("Matchbox Count: " + matchCount);
    }
}
