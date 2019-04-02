using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {

    public string equipName;
    public Texture pic;
    public int buyValue;
    public int sellValue;

    void Start()
    {
        equipName = "";
        pic = null;
    }
}