using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    // public vars 
    public TextMeshProUGUI batteryText;
    public TextMeshProUGUI matchText;  
    public Stack<Item> batteryStack = new Stack<Item>();
    public Stack<Item> matchStack = new Stack<Item>();
    public ItemData gameItems; 
    public static int batteryCount = 0;
    public static int matchCount = 0;

    // Runs at the beginning of the scene 
    private void awake()
    {
        batteryText.enabled = false;
        matchText.enabled = false; 

    }
    // Runs for every frame 
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ShowInventory();
        }
        else 
        {
            batteryText.enabled = false;
            matchText.enabled = false;  
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
            batteryCount -= 1; 
        }
        else if (matchStack.Count > 0)
        {
            matchStack.Pop();
            matchCount -= 1; 
        }
        ShowInventory();
    }

    public void PopBatteryStack()
    {
        if (batteryStack.Count > 0)
        {
            batteryStack.Pop();
            batteryCount -= 1;
        }
        else
        {
            Debug.Log("There are no batteries in your inventory");
        }
    }

    public void PopMatchStack()
    {
        if (matchStack.Count > 0)
        {
            matchStack.Pop();
            matchCount -= 1;
        }
        else 
        {
            Debug.Log("There are no Matches in your inventory");
        }
        
    }

    // Displays the current inventory of the Player 
    public void ShowInventory()
    {
        batteryText.SetText("Batteries: " + batteryCount);
        batteryText.enabled = true; 

        matchText.SetText("Matches: " + matchCount);
        matchText.enabled = true; 
    }
}
