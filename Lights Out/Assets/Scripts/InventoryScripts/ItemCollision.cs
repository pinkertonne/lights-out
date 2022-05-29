using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  this is a class that handles player and Item interaction
*/
public class ItemCollision : MonoBehaviour
{
    // True if the player can pick up the Item
    private bool pickable; 

    // Object vars 
    public PlayerInventory inventory;
    public GameObject parentObject;
    public LayerMask mask; 
    public Item item;

    // Called at the beginning of the script
    private void Start()
    {
        pickable = false;
    }

    // Called after each frame 
    private void Update()
    {
        if (pickable && Input.GetMouseButtonUp(0)) // checks to see if player 
        {//tries to pickup the object
            pickItem(item);
        }
    }

    // Called when the player enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && inSight())
        {
            pickable = true; 
        }
    }

    // Called when the Player exits the trigger zone 
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickable = false; 
        }
    }

    // Checks if the player is looking at the object 
    private bool inSight()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, mask))
        {
            return true;
        }
        else 
        {
            return false; 
        }
    }

    // Adds the item to the players inventory 
    public void pickItem(Item item)
    {
        inventory.AddItem(item.itemId);
        parentObject.SetActive(false);
    }
}



