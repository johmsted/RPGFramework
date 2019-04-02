using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour {

    public string charName;
    public Texture pic;
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
    public List<Skill> skills = new List<Skill>();
    public List<Spell> spells = new List<Spell>();

    public void restore()
    {
        curr_health = max_health;
        curr_mana = max_mana;
        
    }

    public void fillAbilities()
    {
        for (var i = 0; i < GameObject.Find("Database").GetComponents<Skill>().Length; i++)
        {
            skills.Add(GameObject.Find("Database").GetComponents<Skill>()[i]);
        }

        for (var i = 0; i < GameObject.Find("Database").GetComponents<Spell>().Length; i++)
        {
            spells.Add(GameObject.Find("Database").GetComponents<Spell>()[i]);
        }
    }

    public void newGameCharacter(string charName, string imgPath, int maxHP, int maxMP, int attack, int magicAtk, int defense, float[] res, List<Skill> skills, List<Spell> spells)
    {
        this.charName = charName;

        //connect image
        pic = (Texture)Resources.Load("Textures/Characters/" + imgPath);
        //pic = img;

        max_health = maxHP;
        curr_health = maxHP;
        max_mana = maxMP;
        curr_mana = maxMP;
        this.attack = attack;
        magic_attack = magicAtk;
        this.defense = defense;
        fireRes = res[0];
        wtrRes = res[1];
        elecRes = res[2];
        holyRes = res[3];
        darkRes = res[4];
        this.skills = skills;
        this.spells = spells;        
    }

    public void copy(Character other)
    {
        charName = other.charName;
        pic = other.pic;
        max_health = other.max_health;
        curr_health = other.curr_health;
        max_mana = other.max_mana;
        curr_mana = other.curr_mana;
        attack = other.attack;
        magic_attack = other.magic_attack;
        defense = other.defense;
        fireRes = other.fireRes;
        wtrRes = other.wtrRes;
        elecRes = other.elecRes;
        holyRes = other.holyRes;
        darkRes = other.darkRes;
        skills = other.skills;
        spells = other.spells;
    }

    public CharacterSaveData convertToSerializable()
    {
        CharacterSaveData csd = new CharacterSaveData();

        csd.charName = charName;
        csd.max_health = max_health;
        csd.curr_health = curr_health;
        csd.max_mana = max_mana;
        csd.curr_mana = curr_mana;
        csd.attack = attack;
        csd.magic_attack = magic_attack;
        csd.defense = defense;
        csd.fireRes = fireRes;
        csd.wtrRes = wtrRes;
        csd.elecRes = elecRes;
        csd.holyRes = holyRes;
        csd.darkRes = darkRes;

        for (var i = 0; i < skills.Count; i++)
        {
            csd.skills.Add(skills[i].abilityName);
        }

        for (var i = 0; i < spells.Count; i++)
        {
            csd.spells.Add(spells[i].abilityName);
        }

        return csd;
    }

    public void convertToMono(CharacterSaveData csd)
    {
        charName = csd.charName;
        pic = (Texture)Resources.Load("Textures/Characters/" + charName);
        max_health = csd.max_health;
        curr_health = csd.curr_health;
        max_mana = csd.max_mana;
        curr_mana = csd.curr_mana;
        attack = csd.attack;
        magic_attack = csd.magic_attack;
        defense = csd.defense;
        fireRes = csd.fireRes;
        wtrRes = csd.wtrRes;
        elecRes = csd.elecRes;
        holyRes = csd.holyRes;
        darkRes = csd.darkRes;

        for (var i = 0; i < csd.skills.Count; i++) {
            skills.Add(LoadSave.ls.gameObject.GetComponent<LoadSkillsXML>().find(csd.skills[i]));
        }

        for (var i = 0; i < csd.spells.Count; i++)
        {
            spells.Add(LoadSave.ls.gameObject.GetComponent<LoadSpellsXML>().find(csd.spells[i]));
        }
    }

}
