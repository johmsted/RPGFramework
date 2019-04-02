using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SaveBattleMenu : MonoBehaviour {
    public PlayerTurnState state_machine;

    public Button saveMain;
    public Button saveExit;
    public Button close;

    void Start()
    {
        saveMain.onClick.AddListener(delegate { saveAndMain(); });
        saveExit.onClick.AddListener(delegate { saveAndExit(); });
        close.onClick.AddListener(delegate { closeMenu(); });
    }

	public void saveAndMain()
    {
        LoadSave.ls.BattleSave();
        gameObject.SetActive(false);
        Destroy(LoadSave.ls.gameObject);
        Destroy(Inventory.inventory.gameObject);
        SceneManager.LoadScene(0);
    }

    public void saveAndExit()
    {
        LoadSave.ls.BattleSave();
        gameObject.SetActive(false);
        Application.Quit();

        //For testing in editor WILL NOT BUILD WITH THIS LINE
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void closeMenu()
    {
        gameObject.SetActive(false);
        state_machine.setState(0);
    }
}
