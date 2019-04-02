using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterSaveData {
    public string charName;
    //public Texture pic;
    public int level;
    public int max_health;
    public int curr_health;
    public int max_mana;
    public int curr_mana;
    public int attack;
    public int magic_attack;
    public int defense;
    public float fireRes;
    public float wtrRes;
    public float elecRes;
    public float holyRes;
    public float darkRes;
    public List<string> skills = new List<string>();
    public List<string> spells = new List<string>();

}
