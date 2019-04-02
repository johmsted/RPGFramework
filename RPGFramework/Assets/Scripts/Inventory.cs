using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public static Inventory inventory;

    public List<Item> items = new List<Item>();

    void Awake()
    {
        if (inventory == null)
        {
            DontDestroyOnLoad(gameObject);
            inventory = this;
        }
        else if (inventory != this)
        {
            Destroy(gameObject);
        }
    }

    public void addToInventory(string itemName, int quantity)
    {
        for(var i = 0; i < inventory.items.Count; i++)
        {
            if(itemName == inventory.items[i].itemName)
            {
                inventory.items[i].quantity += quantity;
                return;
            }
        }
        gameObject.AddComponent<Item>();
        gameObject.GetComponents<Item>()[gameObject.GetComponents<Item>().Length-1].copy(LoadSave.ls.gameObject.GetComponent<LoadItemsXML>().find(itemName));
        gameObject.GetComponents<Item>()[gameObject.GetComponents<Item>().Length-1].quantity = quantity;
        inventory.items.Add(gameObject.GetComponents<Item>()[gameObject.GetComponents<Item>().Length-1]);
    }

}
