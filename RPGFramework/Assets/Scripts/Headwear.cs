using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headwear : Equipment {
    public int defense;
    public float fireRes;
    public float wtrRes;
    public float elecRes;
    public float holyRes;
    public float darkRes;

    void Start()
    {
        defense = 0;
        fireRes = 0;
        wtrRes = 0;
        elecRes = 0;
        holyRes = 0;
        darkRes = 0;
    }
}