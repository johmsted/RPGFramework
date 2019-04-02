using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour {

    public void quit()
    {
        Application.Quit();
        //For testing in editor WILL NOT BUILD WITH THIS LINE
        UnityEditor.EditorApplication.isPlaying = false;
    }
	
}
