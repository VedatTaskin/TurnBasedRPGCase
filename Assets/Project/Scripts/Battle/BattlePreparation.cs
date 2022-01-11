using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Hero list taken and "players" are preparing
public class BattlePreparation : MonoBehaviour
{
    public GameObject defaultPlayerGO; // default gameobject will modify according to shape, size, color   
    public GameObject enemy;
    float offsetY = 3.5f;


    private void OnEnable()
    {
        EventManager.heroesAreChosenForBattle += CreatePlayers;
        enemy.SetActive(false);
    }

    private void OnDisable()
    {
        EventManager.heroesAreChosenForBattle -= CreatePlayers;
    }

    // player features are defining;
    private void CreatePlayers(Dictionary<int, Hero> _heroes)
    {
        int i = 0; // change position of object for next iteration

        foreach (var item in _heroes)
        {

            GameObject playerGO = (GameObject)Instantiate(defaultPlayerGO);

            // we will assign values to Gameobject;
            playerGO.name = item.Value.Name;
            playerGO.GetComponent<SpriteRenderer>().material = item.Value.material;
            playerGO.GetComponent<SpriteRenderer>().sprite = item.Value.sprite;
            playerGO.GetComponent<Transform>().localScale *= (int)item.Value.sizeType;
            playerGO.GetComponent<PlayerControl>().AP = item.Value.AP;
            playerGO.GetComponent<PlayerControl>().HP = item.Value.HP;
            SetPosition(i, playerGO);

            EventManager.onPlayerCreated?.Invoke(playerGO);
            i++;
        }

        enemy.SetActive(true);
    }

    // we can do better placement later :)
    private void SetPosition(int i, GameObject playerGO)
    {
        if (i%2==0)
        {
            playerGO.transform.position = new Vector2(-6, offsetY * i - 3);  // we can do better placement later
        }
        else
        {
            playerGO.transform.position = new Vector2(-3, offsetY * i - 3);  // we can do better placement later
        }
       
    }
}
