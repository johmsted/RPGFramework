using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHoverTile : MonoBehaviour
{

    public GameObject targetPanel;
    public PlayerTurnState state_machine;
    public BattleMenuManager bmm;
    public UIUpdates uiUpdater;

    public Text targetName;
    public RawImage img;
    public Text hpValue;
    public Text mpValue;
    public Text atkValue;
    public Text defValue;
    public Text magValue;
    public Text fireRes;
    public Text wtrRes;
    public Text elecRes;
    public Text holyRes;
    public Text darkRes;

    private bool targetImgActive = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (state_machine.getState() == 1 || state_machine.getState() == 2)
            {
                state_machine.setState(0);
                bmm.closeAttackMenu();
                state_machine.setAbility(null);
            }
            else if (state_machine.getState() == 3 || state_machine.getState() == 4 || state_machine.getState() == 5)
            {
                state_machine.setState(0);
                bmm.closeSpellMenu();
                state_machine.setAbility(null);
            }
            else if (state_machine.getState() == 6 || state_machine.getState() == 7)
            {
                state_machine.setState(0);
                bmm.closeItemMenu();
                state_machine.setCurrItem(null);
            }
        }
    }

    void OnMouseOver()
    {
        bool canTargetEnemy = state_machine.getState() == 0 || state_machine.getState() == 1 || state_machine.getState() == 2 || state_machine.getState() == 3 || state_machine.getState() == 4;
        bool canTargetAlly = state_machine.getState() == 3 || state_machine.getState() == 5 || state_machine.getState() == 6 || state_machine.getState() == 7;
        if (gameObject.CompareTag("EnemyTile") && canTargetEnemy || (gameObject.CompareTag("PlayerTile") && canTargetAlly))
        {

            if (targetPanel.activeSelf == false)
            {
                targetPanel.SetActive(true);
            }

            if (targetImgActive == false)
            {
                targetImgActive = true;
                if (gameObject.CompareTag("EnemyTile"))
                {
                    img.texture = GetComponent<Monster>().pic;

                    targetName.text = GetComponent<Monster>().monsterName;

                    hpValue.text = gameObject.GetComponent<Monster>().curr_health.ToString() + "/" + gameObject.GetComponent<Monster>().max_health.ToString();
                    mpValue.text = gameObject.GetComponent<Monster>().curr_mana.ToString() + "/" + gameObject.GetComponent<Monster>().max_mana.ToString();

                    atkValue.text = gameObject.GetComponent<Monster>().attack.ToString();
                    defValue.text = gameObject.GetComponent<Monster>().defense.ToString();
                    magValue.text = gameObject.GetComponent<Monster>().magic_attack.ToString();

                    float resMulti = gameObject.GetComponent<Monster>().fireRes * 100;
                    fireRes.text = resMulti.ToString() + "%";

                    resMulti = gameObject.GetComponent<Monster>().wtrRes * 100;
                    wtrRes.text = resMulti.ToString() + "%";

                    resMulti = gameObject.GetComponent<Monster>().elecRes * 100;
                    elecRes.text = resMulti.ToString() + "%";

                    resMulti = gameObject.GetComponent<Monster>().holyRes * 100;
                    holyRes.text = resMulti.ToString() + "%";

                    resMulti = gameObject.GetComponent<Monster>().darkRes * 100;
                    darkRes.text = resMulti.ToString() + "%";
                }
                else
                {
                    img.texture = GetComponent<Character>().pic;

                    targetName.text = GetComponent<Character>().charName;

                    hpValue.text = gameObject.GetComponent<Character>().curr_health.ToString() + "/" + gameObject.GetComponent<Character>().max_health.ToString();
                    mpValue.text = gameObject.GetComponent<Character>().curr_mana.ToString() + "/" + gameObject.GetComponent<Character>().max_mana.ToString();

                    atkValue.text = gameObject.GetComponent<Character>().attack.ToString();
                    defValue.text = gameObject.GetComponent<Character>().defense.ToString();
                    magValue.text = gameObject.GetComponent<Character>().magic_attack.ToString();

                    float resMulti = gameObject.GetComponent<Character>().fireRes * 100;
                    fireRes.text = resMulti.ToString() + "%";

                    resMulti = gameObject.GetComponent<Character>().wtrRes * 100;
                    wtrRes.text = resMulti.ToString() + "%";

                    resMulti = gameObject.GetComponent<Character>().elecRes * 100;
                    elecRes.text = resMulti.ToString() + "%";

                    resMulti = gameObject.GetComponent<Character>().holyRes * 100;
                    holyRes.text = resMulti.ToString() + "%";

                    resMulti = gameObject.GetComponent<Character>().darkRes * 100;
                    darkRes.text = resMulti.ToString() + "%";
                }
            }
        }
    }

    void OnMouseDown()
    {
        if (state_machine.getState() == 2)
        {
            if (gameObject.CompareTag("EnemyTile") && state_machine.getAbility().manaCost <= state_machine.getCurrCharac().curr_mana)
            {
                attack(gameObject.GetComponent<Monster>());
                state_machine.setState(0);
                bmm.closeAttackMenu();
            }
            else
            {
                if (!gameObject.CompareTag("EnemyTile"))
                {
                    Debug.Log("Wrong target!");
                }
                else
                {
                    Debug.Log("Not enough Mana!");
                }
            }
        }
        else if (state_machine.getState() == 4)
        {
            if (gameObject.CompareTag("EnemyTile") && state_machine.getAbility().manaCost <= state_machine.getCurrCharac().curr_mana)
            {
                cast(gameObject.GetComponent<Monster>());
                state_machine.setState(0);
                bmm.closeSpellMenu();
            }
            else
            {
                if (!gameObject.CompareTag("EnemyTile"))
                {
                    Debug.Log("Wrong target!");
                }
                else
                {
                    Debug.Log("Not enough Mana!");
                }
            }
        }
        else if (state_machine.getState() == 5)
        {
            if (gameObject.CompareTag("PlayerTile") && state_machine.getAbility().manaCost <= state_machine.getCurrCharac().curr_mana)
            {
                castSupport(gameObject.GetComponent<Character>());
                state_machine.setState(0);
                bmm.closeSpellMenu();
            }
            else
            {
                if (!gameObject.CompareTag("PlayerTile"))
                {
                    Debug.Log("Wrong target!");
                }
                else
                {
                    Debug.Log("Not enough Mana!");
                }
            }
        }
        else if (state_machine.getState() == 7)
        {
            if (gameObject.CompareTag("PlayerTile"))
            {
                useItem(gameObject.GetComponent<Character>());
                state_machine.setState(0);
                bmm.closeItemMenu();
            }
            else
            {
                Debug.Log("Wrong target!");
            }
        }
    }

    void OnMouseExit()
    {
        bool canTargetAlly = state_machine.getState() == 3 || state_machine.getState() == 5 || state_machine.getState() == 6 || state_machine.getState() == 7;
        if (gameObject.CompareTag("EnemyTile") || (gameObject.CompareTag("PlayerTile") && canTargetAlly))
        {
            targetImgActive = false;
        }
    }

    void attack(Monster target)
    {
        state_machine.getCurrCharac().curr_mana -= state_machine.getAbility().manaCost;

        Random.InitState((int)Time.time);

        //Calculate elemental damage
        int elemDam = 0;
        int atk = state_machine.getCurrCharac().attack;
        int mt = state_machine.getAbility().mt;
        string elem = state_machine.getAbility().element;

        if (elem != "")
        {
            atk = atk / 2;
            if (elem == "fire")
            {
                elemDam = (int)((atk + mt / 2) * target.fireRes);
            }
            else if (elem == "wtr")
            {
                elemDam = (int)((atk + mt / 2) * target.wtrRes);
            }
            else if (elem == "elec")
            {
                elemDam = (int)((atk + mt / 2) * target.elecRes);
            }
            else if (elem == "holy")
            {
                elemDam = (int)((atk + mt / 2) * target.holyRes);
            }
            else if (elem == "dark")
            {
                elemDam = (int)((atk + mt / 2) * target.darkRes);
            }
            elemDam = (int)(Random.Range(0.8f, 1.2f) * elemDam);
        }

        //Calculate total damage roll
        int damageRoll = (int)(Random.Range(0.8f, 1.2f) * (atk + state_machine.getAbility().mt) / 2);
        Debug.Log(state_machine.getCurrCharac().charName + " used " + state_machine.getAbility().abilityName + "!");
        if (damageRoll <= target.defense && elemDam == 0)
        {
            target.curr_health--;
        }
        else if (damageRoll <= target.defense && elemDam != 0)
        {
            target.curr_health = target.curr_health - elemDam - 1;
        }
        else
        {
            target.curr_health = (target.curr_health - elemDam) - (damageRoll - target.defense);
        }
        if (target.curr_health < 0)
        {
            target.curr_health = 0;
        }
        hpValue.text = gameObject.GetComponent<Monster>().curr_health.ToString() + "/" + gameObject.GetComponent<Monster>().max_health.ToString();
        uiUpdater.updateMana(state_machine.getCurrCharac());
    }

    void cast(Monster target)
    {
        state_machine.getCurrCharac().curr_mana -= state_machine.getAbility().manaCost;

        Random.InitState((int)Time.time);

        //Calculate elemental damage
        int elemDam = 0;
        int magAtk = state_machine.getCurrCharac().magic_attack;
        int spellMt = state_machine.getAbility().mt;
        string elem = state_machine.getAbility().element;

        if (elem != "")
        {
            if (elem == "fire")
            {
                elemDam = (int)((magAtk + spellMt) * target.fireRes);
            }
            else if (elem == "wtr")
            {
                elemDam = (int)((magAtk + spellMt) * target.wtrRes);
            }
            else if (elem == "elec")
            {
                elemDam = (int)((magAtk + spellMt) * target.elecRes);
            }
            else if (elem == "holy")
            {
                elemDam = (int)((magAtk + spellMt) * target.holyRes);
            }
            else if (elem == "dark")
            {
                elemDam = (int)((magAtk + spellMt) * target.darkRes);
            }
        }
        int damageRoll = (int)(Random.Range(0.8f, 1.2f) * elemDam);
        Debug.Log(state_machine.getCurrCharac().charName + " used " + state_machine.getAbility().abilityName + "!");
        Debug.Log("Damage Roll: " + damageRoll);

        target.curr_health = target.curr_health - damageRoll;
        if (target.curr_health < 0)
        {
            target.curr_health = 0;
        }
        hpValue.text = gameObject.GetComponent<Monster>().curr_health.ToString() + "/" + gameObject.GetComponent<Monster>().max_health.ToString();
        uiUpdater.updateMana(state_machine.getCurrCharac());
    }

    void castSupport(Character target)
    {
        state_machine.getCurrCharac().curr_mana -= state_machine.getAbility().manaCost;

        Random.InitState((int)Time.time);

        int healValue = (int)(Random.Range(0.8f, 1.2f) * (state_machine.getAbility().mt + state_machine.getCurrCharac().magic_attack));

        target.curr_health = target.curr_health + healValue;
        if (target.curr_health > target.max_health)
        {
            target.curr_health = target.max_health;
        }
        hpValue.text = gameObject.GetComponent<Character>().curr_health.ToString() + "/" + gameObject.GetComponent<Character>().max_health.ToString();
        Debug.Log(state_machine.getCurrCharac().charName + " used " + state_machine.getAbility().abilityName + "!");
        uiUpdater.updateMana(state_machine.getCurrCharac());
    }

    void useItem(Character target)
    {
        if (state_machine.getCurrItem().itemFunction == 0)
        {
            target.curr_health = target.curr_health + state_machine.getCurrItem().value;
            if (target.curr_health > target.max_health)
            {
                target.curr_health = target.max_health;
            }
            hpValue.text = gameObject.GetComponent<Character>().curr_health.ToString() + "/" + gameObject.GetComponent<Character>().max_health.ToString();
        }
        else if (state_machine.getCurrItem().itemFunction == 1)
        {
            target.curr_mana = target.curr_mana + state_machine.getCurrItem().value;
            if (target.curr_mana > target.max_mana)
            {
                target.curr_mana = target.max_mana;
            }
            mpValue.text = gameObject.GetComponent<Character>().curr_mana.ToString() + "/" + gameObject.GetComponent<Character>().max_mana.ToString();
        }
        else if (state_machine.getCurrItem().itemFunction == 2)
        {

        }
        else if (state_machine.getCurrItem().itemFunction == 3)
        {

        }
        bmm.decreaseItem(state_machine.getCurrItem());
    }
}
