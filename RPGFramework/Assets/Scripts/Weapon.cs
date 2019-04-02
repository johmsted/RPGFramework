using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment {
    public int attack;
    public int magic_attack;
    public int mana;
    public string element;

    void Start()
    {
        attack = 0;
        magic_attack = 0;
        mana = 0;
        element = "";
    }
}