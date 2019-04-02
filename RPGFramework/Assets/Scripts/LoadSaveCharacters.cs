using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveCharacters : MonoBehaviour {

    public List<Character> charDB = new List<Character>();

    /*
    JacerCo = 0
    PurelyPJ = 1
    BMills = 2
    add more when necessary
    */

	// Use this for initialization
	void Start () {
        LoadSave.ls.lsc = this;
        for (var i = 0; i < LoadSave.ls.charList.Count; i++)
        {
            charDB.Add(LoadSave.ls.charList[i]);
            gameObject.transform.GetChild(i).gameObject.AddComponent<Character>();
            gameObject.transform.GetChild(i).gameObject.GetComponent<Character>().copy(charDB[i]);
        }
    }
	
    public void saveChars()
    {
        for (var i = 0; i < charDB.Count; i++)
        {
            charDB[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<Character>();
            LoadSave.ls.charList[i].copy(charDB[i]);
        }
    }
}
