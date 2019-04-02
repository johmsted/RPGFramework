using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTile : MonoBehaviour {

    public GameObject playerPanel;
    public GameObject actionPanel;
    public PlayerTurnState state_machine;

    public Text charName;
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

    void OnMouseDown()
    {
        if (state_machine.getState() == 0)
        {
            if (gameObject.CompareTag("PlayerTile"))
            {
                if (playerPanel.activeSelf == false)
                {
                    playerPanel.SetActive(true);
                }

                if (actionPanel.activeSelf == false)
                {
                    actionPanel.SetActive(true);
                }

                state_machine.setCurrCharac(gameObject.GetComponent<Character>());

                if (gameObject.GetComponent<Character>().skills.Count == 0) {
                    gameObject.GetComponent<Character>().fillAbilities();
                }
                img.texture = GetComponent<Character>().pic;

                charName.text = GetComponent<Character>().charName;
             
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
