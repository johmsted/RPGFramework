using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour{

    public string abilityName;
    public string type; //Single, row, column, aoe - potentially done with an int for states instead
    public Effect effect; //Bleed, burn, provoke, etc.
    public string element; //elemental attribute associated with skill
    public int manaCost;
    public int mt; //Stealing fire emblem naming sue me I deer you
    public bool isSupport;

    /// <summary>
    /// Fill ability info with effect and element
    /// </summary>
    /// <param name="abilityName"></param>
    /// <param name="type"></param>
    /// <param name="effect"></param>
    /// <param name="element"></param>
    /// <param name="manaCost"></param>
    /// <param name="mt"></param>
    /// <param name="isSupport"></param>
    public void fill(string abilityName, string type, Effect effect,  string element, int manaCost, int mt, bool isSupport)
    {
        this.abilityName = abilityName;
        this.type = type;
        this.effect = effect;
        this.element = element;
        this.manaCost = manaCost;
        this.mt = mt;
        this.isSupport = isSupport;
    }

    public void copy(Ability other)
    {
        this.abilityName = other.abilityName;
        this.type = other.type;
        this.effect = other.effect;
        this.element = other.element;
        this.manaCost = other.manaCost;
        this.mt = other.mt;
        this.isSupport = other.isSupport;
    }
}
