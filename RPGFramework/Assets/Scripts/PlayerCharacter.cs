using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character {

    //Growths Array
    //0 hp
    //1 mana
    //2 attack
    //3 magic attack
    //4 defense
    public float[] growths;
    public int exp;

    void Start()
    {
        curr_health = max_health;
        curr_mana = max_mana;
        growths = new float[5];
    }

    void LevelUp(){
        Random.InitState((int)Time.time);

        int healthRoll = (int)(Random.Range(0.8f, 1.2f) * (growths[0] * max_health));
        max_health += healthRoll;

        int manaRoll = (int)(Random.Range(0.8f, 1.2f) * (growths[1] * max_mana));
        max_mana += manaRoll;

        int attackRoll = (int)(Random.Range(0.8f, 1.2f) * (growths[2] * attack));
        attack += attackRoll;

        int magicAttackRoll = (int)(Random.Range(0.8f, 1.2f) * (growths[3] * magic_attack));
        magic_attack += magicAttackRoll;

        int defenseRoll = (int)(Random.Range(0.8f, 1.2f) * (growths[4] * defense));
        defense += defenseRoll;
    }
}
