using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    Dictionary<int, Hero> heroesInBattle = new Dictionary<int, Hero>();

    private void OnEnable()
    {
        EventManager.isBattleStarted += BattleStart;
        EventManager.chosenHeroesForBattle += CreatePlayers;
    }

    private void OnDisable()
    {
        EventManager.isBattleStarted -= BattleStart;
        EventManager.chosenHeroesForBattle += CreatePlayers;
    }

    private void BattleStart(bool obj)
    {
        if (obj)
        {
            print("battle start with");

        }

        else
        {
            print("battle finished");
        }
    }

    public void CreatePlayers(Dictionary<int,Hero> chosenHeroes)
    {
        heroesInBattle = chosenHeroes;
        foreach (var item in chosenHeroes)
        {
            print(item.Value.Name);
        }

        //var player = Resources.Load<GameObject>("Circle");
    }

    
}
