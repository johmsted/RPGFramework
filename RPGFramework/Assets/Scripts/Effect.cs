using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect {
    public string name;
    public float chance;

    public Effect(string name)
    {
        this.name = name;
        chance = 0;
    }

    public Effect(string name, float chance)
    {
        this.name = name;
        this.chance = chance;
    }

    public void fill(string name, float chance)
    {
        this.name = name;
        this.chance = chance;
    }
}
