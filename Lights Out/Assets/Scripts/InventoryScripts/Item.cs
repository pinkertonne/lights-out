using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item class for our inventory management 
public class Item : MonoBehaviour
{
    public int itemId; // Item id
    public float itemStatus; // Item status
    public string itemTitle; // Item name
    public string aboutItem; // Item Description
    public GameObject prefab;
    
    // Item object constructor 
    public Item(int id, string title)
    {
        this.itemId = id;
        this.itemTitle = title;
        this.prefab = Resources.Load<GameObject>("Assets/Items/" + title);
        this.itemStatus = 100f;
    }

    // Item object copy constructor 
    public Item(Item item)
    {
        this.itemId = item.itemId;
        this.itemTitle = item.itemTitle;
        this.prefab = Resources.Load<GameObject>("Assets/Items/" + item.itemTitle);;
        this.itemStatus = item.itemStatus;
    }
}
