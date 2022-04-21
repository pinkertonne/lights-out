using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item class for our inventory management 
public class Item
{
    public int itemId; // Item id
    public string itemTitle; // Item name
    public string aboutItem; // Item Description
    public Sprite icon; // Image of the item in our world 
    public Dictionary<string, float> itemStatus = new Dictionary<string, float>(); // status of the item along with the status value 
    // Ie. How full a battery is, how much time left a lit candle has...

    public Item(int id, string title, string description, Sprite picture, Dictionary<string, float> status)
    {
        this.itemId = id;
        this.itemTitle = title;
        this.aboutItem = description;
       // this->icon = Resources.load<Sprite>(load from a directory here);
       this.itemStatus = status;
    }
}
