using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : MonoBehaviour {

    //0 starting state
    //1 select attack
    //2 select attack target
    //3 select spell
    //4 select spell enemy target
    //5 select spell ally target
    //6 select item
    //7 select item ally target

    private int player_turn_state = 0;
    private Character curr_character;
    private Ability curr_ability;
    private Item curr_item;

	public int getState()
    {
        return player_turn_state;
    }

    public void setState(int state)
    {
        player_turn_state = state;
    }

    public Character getCurrCharac()
    {
        return curr_character;
    }

    public void setCurrCharac(Character charac)
    {
        curr_character = charac;
    }

    public Ability getAbility()
    {
        return curr_ability;
    }

    public void setAbility(Ability ability)
    {
        curr_ability = ability;
    }

    public Item getCurrItem()
    {
        return curr_item;
    }

    public void setCurrItem(Item item)
    {
        curr_item = item;
    }
}
