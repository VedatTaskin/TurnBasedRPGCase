using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    Dictionary<int, Hero> heroesForBattle = new Dictionary<int, Hero>();

    private void OnEnable()
    {
        EventManager.chosenHeroesForBattle += CreatePlayer;
    }


    private void OnDisable()
    {
        EventManager.chosenHeroesForBattle -= CreatePlayer;
    }

    private void CreatePlayer(Dictionary<int, Hero> _heroes)
    {
        heroesForBattle = _heroes;

        foreach (var item in heroesForBattle)
        {
            print(item.Value.Name);
        }
    }
}
