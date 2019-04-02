using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadButton : MonoBehaviour {

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { loadPushed(); });
    }

	public void loadPushed()
    {
        LoadSave.ls.Load();
    }
}
