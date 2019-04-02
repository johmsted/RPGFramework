using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTile : MonoBehaviour {

    public Material playerHovered;
    public Material player;
    public Material enemyHovered;
    public Material enemy;

    void OnMouseOver()
    {
        if (gameObject.CompareTag("PlayerTile"))
        {
            gameObject.GetComponent<MeshRenderer>().material = playerHovered;
        } else if (gameObject.CompareTag("EnemyTile")){
            gameObject.GetComponent<MeshRenderer>().material = enemyHovered;
        }
    }

    void OnMouseExit()
    {
        if (gameObject.CompareTag("PlayerTile"))
        {
            gameObject.GetComponent<MeshRenderer>().material = player;
        }else if (gameObject.CompareTag("EnemyTile"))
        {
            gameObject.GetComponent<MeshRenderer>().material = enemy;
        }
    }

}
