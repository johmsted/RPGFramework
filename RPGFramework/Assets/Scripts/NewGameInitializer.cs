using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewGameInitializer : MonoBehaviour {

    public Texture jc, pj, brandon;
    public GameObject database;
    public GameObject inventory;

    void Start()
    {
        database = LoadSave.ls.gameObject;
        inventory = Inventory.inventory.gameObject;
    }

	public void newGame()
    {
        database.AddComponent<Character>();
        float[] res1 = new float[5] {.10f, .10f, .10f, .20f, .20f};
        List<Skill> skills1 = new List<Skill>();
        skills1.Add(database.GetComponent<LoadSkillsXML>().find("Basic Attack"));
        skills1.Add(database.GetComponent<LoadSkillsXML>().find("Lunge"));
        List<Spell> spells1 = new List<Spell>();
        database.GetComponent<Character>().newGameCharacter("JacerCo", "JacerCo", 20, 15, 10, 5, 5, res1, skills1, spells1);
        LoadSave.ls.charList.Add(database.GetComponent<Character>());

        database.AddComponent<Character>();
        float[] res2 = new float[5] { .15f, .15f, .15f, .10f, .10f };
        List<Skill> skills2 = new List<Skill>();
        skills2.Add(database.GetComponent<LoadSkillsXML>().find("Basic Attack"));
        List<Spell> spells2 = new List<Spell>();
        spells2.Add(database.GetComponent<LoadSpellsXML>().find("Fireball"));
        database.GetComponents<Character>()[1].newGameCharacter("PurelyPJ", "PurelyPJ", 18, 30, 4, 12, 2, res2, skills2, spells2);
        LoadSave.ls.charList.Add(database.GetComponents<Character>()[1]);

        database.AddComponent<Character>();
        float[] res3 = new float[5] { .25f, .25f, .25f, .25f, .25f };
        List<Skill> skills3 = new List<Skill>();
        skills3.Add(database.GetComponent<LoadSkillsXML>().find("Basic Attack"));
        List<Spell> spells3 = new List<Spell>();
        spells3.Add(database.GetComponent<LoadSpellsXML>().find("Heal"));
        database.GetComponents<Character>()[2].newGameCharacter("BMills", "BMills", 30, 10, 8, 8, 2, res3, skills3, spells3);
        LoadSave.ls.charList.Add(database.GetComponents<Character>()[2]);

        inventory.GetComponent<Inventory>().addToInventory("Small Potion", 4);
        inventory.GetComponent<Inventory>().addToInventory("Small Elixer", 2);

        SceneManager.LoadScene(1);
    }
}
