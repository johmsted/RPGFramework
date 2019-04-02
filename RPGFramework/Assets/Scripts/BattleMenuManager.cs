using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenuManager : MonoBehaviour
{
    public PlayerTurnState state_machine;

    public GameObject attack_button;
    public GameObject spell_button;
    public GameObject item_button;

    public GameObject action_menu;

    public GameObject skill_select;
    public GameObject support_skill_select;
    public GameObject item_select;

    public GameObject action_content;

    public GameObject inventoryObject;

    void Start()
    {
        inventoryObject = Inventory.inventory.gameObject;
    }

    //***Attack Functions***
    public void openAttackMenu()
    {
        if (state_machine.getState() == 1)
        {
            spell_button.SetActive(false);
            item_button.SetActive(false);
            action_menu.SetActive(true);
        }
    }

    public void closeAttackMenu()
    {
        spell_button.SetActive(true);
        item_button.SetActive(true);
        action_menu.SetActive(false);

        foreach (Transform child in action_content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void fillAttackMenu()
    {
        //Vector3 v3 = new Vector3(6.2f, 136.6f);

        foreach (Transform child in action_content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (var i = 0; i < state_machine.getCurrCharac().skills.Count; i++)
        {
            GameObject skillButton = Instantiate(skill_select, action_content.transform, false) as GameObject;
            skillButton.AddComponent<Skill>();
            skillButton.GetComponent<Skill>().copy(state_machine.getCurrCharac().skills[i]);
            skillButton.GetComponent<Button>().onClick.AddListener(delegate { attackSelected(skillButton.GetComponent<Skill>()); });
            skillButton.GetComponent<Transform>().localPosition = new Vector3(skillButton.transform.localPosition.x, skillButton.transform.localPosition.y - (i * 19), skillButton.transform.localPosition.z);
            skillButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = state_machine.getCurrCharac().skills[i].abilityName;
            skillButton.transform.GetChild(1).gameObject.GetComponent<Text>().text = state_machine.getCurrCharac().skills[i].manaCost.ToString();
        }
    }

    public void attackSelected(Skill skill)
    {
        state_machine.setAbility(skill);
        if (skill.isSupport)
        {
            state_machine.setState(5);
        }
        else
        {
            state_machine.setState(2);
        }
    }
    //***End of attack functions***

    //***Spell functions***
    public void openSkillMenu()
    {
        attack_button.SetActive(false);
        item_button.SetActive(false);
        action_menu.SetActive(true);
        if (state_machine.getState() < 3)
        {
            spell_button.transform.localPosition = new Vector3(spell_button.transform.localPosition.x, spell_button.transform.localPosition.y + 30);
        }
        state_machine.setState(3);
    }

    public void fillSpellMenu()
    {
        //Vector3 v3 = new Vector3(6.2f, 136.6f);

        foreach (Transform child in action_content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (var i = 0; i < state_machine.getCurrCharac().spells.Count; i++)
        {
            if (!state_machine.getCurrCharac().spells[i].isSupport)
            {
                GameObject spellButton = Instantiate(skill_select, action_content.transform, false) as GameObject;
                spellButton.AddComponent<Spell>();
                spellButton.GetComponent<Spell>().copy(state_machine.getCurrCharac().spells[i]);
                spellButton.GetComponent<Button>().onClick.AddListener(delegate { spellSelected(spellButton.GetComponent<Spell>()); });
                spellButton.GetComponent<Transform>().localPosition = new Vector3(spellButton.transform.localPosition.x, spellButton.transform.localPosition.y - (i * 19), spellButton.transform.localPosition.z);
                spellButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = state_machine.getCurrCharac().spells[i].abilityName;
                spellButton.transform.GetChild(1).gameObject.GetComponent<Text>().text = state_machine.getCurrCharac().spells[i].manaCost.ToString();
            }
            else
            {
                GameObject spellButton = Instantiate(support_skill_select, action_content.transform, false) as GameObject;
                spellButton.AddComponent<Spell>();
                spellButton.GetComponent<Spell>().copy(state_machine.getCurrCharac().spells[i]);
                spellButton.GetComponent<Button>().onClick.AddListener(delegate { spellSelected(spellButton.GetComponent<Spell>()); });
                spellButton.GetComponent<Transform>().localPosition = new Vector3(spellButton.transform.localPosition.x, spellButton.transform.localPosition.y - (i * 19), spellButton.transform.localPosition.z);
                spellButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = state_machine.getCurrCharac().spells[i].abilityName;
                spellButton.transform.GetChild(1).gameObject.GetComponent<Text>().text = state_machine.getCurrCharac().spells[i].manaCost.ToString();
            }
        }
    }

    public void spellSelected(Spell spell)
    {
        state_machine.setAbility(spell);
        if (spell.isSupport)
        {
            state_machine.setState(5);
            Debug.Log("support detected!");
        }
        else
        {
            state_machine.setState(4);
        }
    }

    public void closeSpellMenu()
    {
        spell_button.transform.localPosition = new Vector3(spell_button.transform.localPosition.x, spell_button.transform.localPosition.y - 30);
        item_button.SetActive(true);
        attack_button.SetActive(true);
        action_menu.SetActive(false);

        foreach (Transform child in action_content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    }
    //***End of spell functions***

    //***Item functions***
    public void openItemMenu()
    {
        attack_button.SetActive(false);
        spell_button.SetActive(false);
        action_menu.SetActive(true);
        if (state_machine.getState() < 6)
        {
            item_button.transform.localPosition = new Vector3(item_button.transform.localPosition.x, item_button.transform.localPosition.y + 60);
        }
        state_machine.setState(6);
    }

    public void fillItemMenu()
    {
        foreach (Transform child in action_content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (var i = 0; i < inventoryObject.GetComponents<Item>().Length; i++)
        {
            GameObject itemButton = Instantiate(item_select, action_content.transform, false) as GameObject;
            itemButton.AddComponent<Item>();
            itemButton.GetComponent<Item>().copy(inventoryObject.GetComponents<Item>()[i]);
            itemButton.GetComponent<Button>().onClick.AddListener(delegate { itemSelected(itemButton.GetComponent<Item>()); });
            itemButton.GetComponent<Transform>().localPosition = new Vector3(itemButton.transform.localPosition.x, itemButton.transform.localPosition.y - (i * 19), itemButton.transform.localPosition.z);
            itemButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = inventoryObject.GetComponents<Item>()[i].itemName;
            itemButton.transform.GetChild(1).gameObject.GetComponent<Text>().text = inventoryObject.GetComponents<Item>()[i].quantity.ToString();
        }
    }

    public void itemSelected(Item item)
    {
        state_machine.setCurrItem(item);
        state_machine.setState(7);
    }

    public void closeItemMenu()
    {
        item_button.transform.localPosition = new Vector3(item_button.transform.localPosition.x, item_button.transform.localPosition.y - 60);
        spell_button.SetActive(true);
        attack_button.SetActive(true);
        action_menu.SetActive(false);

        foreach (Transform child in action_content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        
    }

    public void decreaseItem(Item item)
    {
        string itemName = item.itemName;
        for (var i = 0; i < inventoryObject.GetComponents<Item>().Length; i++)
        {
            if (inventoryObject.GetComponents<Item>()[i].itemName == itemName)
            {
                if (inventoryObject.GetComponents<Item>()[i].quantity > 0)
                {
                    inventoryObject.GetComponents<Item>()[i].quantity--;
                }
                if (inventoryObject.GetComponents<Item>()[i].quantity <= 0) {
                    Destroy(inventoryObject.GetComponents<Item>()[i]);
                }
            }
        }
    }

    //***End of item functions***
}
