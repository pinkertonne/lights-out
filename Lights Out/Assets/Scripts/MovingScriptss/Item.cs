using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item class for our inventory management 
public class Item
{
    public int itemId; // Item id
    public string itemTitle; // Item name
    public string aboutItem; // Item Description
    public GameObject prefab;
    public Dictionary<string, float> itemStatus = new Dictionary<string, float>(); // status of the item along with the status value 
    // Ie. How full a battery is, how much time left a lit candle has...

    
    // Item object constructor 
    public Item(int id, string title, string description, GameObject obj, Dictionary<string,float> status)
    {
        this.itemId = id;
        this.itemTitle = title;
        this.aboutItem = description;
        this.prefab = Resources.Load<GameObject>("Assets/Items/" + title);
        this.itemStatus = status;
    }


    // Item object copy constructor 
    public Item(Item item)
    {
        this.itemId = item.itemId;
        this.itemTitle = item.itemTitle;
        this.aboutItem = item.aboutItem;
        this.prefab = item.prefab;
        this.itemStatus = item.itemStatus;
    }
}
