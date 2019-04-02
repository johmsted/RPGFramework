using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdates : MonoBehaviour {
    public Text hpValue;
    public Text mpValue;

    public void updateMana(Character charac)
    {
        hpValue.text = charac.curr_health.ToString() + "/" + charac.max_health.ToString();
        mpValue.text = charac.curr_mana.ToString() + "/" + charac.max_mana.ToString();
    }
}
