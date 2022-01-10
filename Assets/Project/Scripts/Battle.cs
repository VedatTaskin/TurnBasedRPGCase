using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    Player playerGO;
    Dictionary<int, Player> players = new Dictionary<int, Player>();
    Dictionary<int, Hero> heroesInBattle = new Dictionary<int, Hero>();

    private void OnEnable()
    {
        EventManager.chosenHeroesForBattle += CreatePlayers;
    }

    private void OnDisable()
    {
        EventManager.chosenHeroesForBattle -= CreatePlayers;
    }

    private void Awake()
    {
        playerGO = new Player();
    }

    private void CreatePlayers(Dictionary<int, Hero> _heroes)
    {
        // we clear old player list
        players.Clear();

        foreach (var item in _heroes)
        {
            // shape check
            ShapeCheck(item);
            players.Add(item.Key, playerGO);
            print(item.Value.shapeType);
        }

    }

    // this is not workind
    private void ShapeCheck(KeyValuePair<int, Hero> item)
    {
        if (item.Value.shapeType == ShapeTypes.Circle)
        {
            playerGO.GO = Resources.Load<GameObject>("GameObjects/Circle");
            playerGO.GO.name = "circle";
        }

        else if (item.Value.shapeType == ShapeTypes.Square)
        {
            playerGO.GO = Resources.Load<GameObject>("GameObjects/Square");
            playerGO.GO.name = "square";
        }
    }
}
