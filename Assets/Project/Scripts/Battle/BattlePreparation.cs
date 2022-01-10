using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Hero list taken and "players" are preaparing
public class BattlePreparation : MonoBehaviour
{
    public GameObject defaultPlayerGO; // default gameobject will modify according to shape, size, color   

    float offsetY = 3.5f;


    private void OnEnable()
    {
        EventManager.HeroesAreChosenForBattle += CreatePlayers;        
    }

    private void OnDisable()
    {
        EventManager.HeroesAreChosenForBattle -= CreatePlayers;
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
            playerGO.transform.position = new Vector2(-6, offsetY * i - 3);  // we can do better placement later

            EventManager.players?.Invoke(playerGO);
            i++;
        }
    }
}
