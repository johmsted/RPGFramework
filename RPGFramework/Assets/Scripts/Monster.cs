using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character {
    public string monsterName;
    
    void Start()
    {
        curr_health = max_health;
        curr_mana = max_mana;
    }
}
