using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public string itemName;
    public int quantity;
    public int itemFunction; //0 heal, 1 mana recovery, 2 remove debuff, 3 revive - might be more
    public string debuff; //for debuff removal ex: "burn", "poison"
    public int value; //Amount of hp healed/mana recovered/etc

    public void fill(string itemName, int itemFunction, string debuff, int value)
    {
        this.itemName = itemName;
        quantity = 0;
        this.itemFunction = itemFunction;
        this.debuff = debuff;
        this.value = value;
    }

    public void copy(Item other)
    {
        this.itemName = other.itemName;
        this.quantity = other.quantity;
        this.itemFunction = other.itemFunction;
        this.debuff = other.debuff;
        this.value = other.value;
    }

    public ItemSaveData convertToSerializable()
    {
        ItemSaveData isd = new ItemSaveData();

        isd.itemName = itemName;
        isd.quantity = quantity;
        isd.itemFunction = itemFunction;
        isd.debuff = debuff;
        isd.value = value;

        return isd;
    }

    public void convertToMono(ItemSaveData isd)
    {
        itemName = isd.itemName;
        quantity = isd.quantity;
        itemFunction = isd.itemFunction;
        debuff = isd.debuff;
        value = isd.value;
    }
}
