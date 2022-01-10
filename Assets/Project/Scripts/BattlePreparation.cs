using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Hero list taken and "players" are preaparing
public class BattlePreparation : MonoBehaviour
{
    public GameObject playerGO;  // default gameobject will modify according to shape, size, color

    private void OnEnable()
    {
        EventManager.chosenHeroesForBattle += CreatePlayers;
    }

    private void OnDisable()
    {
        EventManager.chosenHeroesForBattle -= CreatePlayers;
    }

    // player features are defining;
    private void CreatePlayers(Dictionary<int, Hero> _heroes)
    {
        foreach (var item in _heroes)
        {            
            // we will assign values to Gameobject;
            playerGO.name = item.Value.Name;
            playerGO.GetComponent<SpriteRenderer>().material = item.Value.material;
            playerGO.GetComponent<SpriteRenderer>().sprite = item.Value.sprite;
            playerGO.GetComponent<PlayerControl>().AP = item.Value.AP;
            playerGO.GetComponent<PlayerControl>().HP = item.Value.HP;
            Instantiate(playerGO);
            EventManager.players?.Invoke(playerGO);
        }       
    }

}
