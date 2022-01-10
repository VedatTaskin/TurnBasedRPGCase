using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public Player playerSO;  // this contains => Gameobject; HP ; AP
    GameObject playerGO;  // a gameobject will create according to shape, size, color
    SpriteRenderer playerSpriteRenderer;
    Dictionary<int, Player> heroesInBattle = new Dictionary<int, Player>();  // this contains list of PlayerSO

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
        playerSO = new Player();
        playerGO = new GameObject();
        playerSpriteRenderer = playerGO.AddComponent<SpriteRenderer>();
        playerGO.SetActive(false);
    }

    private void CreatePlayers(Dictionary<int, Hero> _heroes)
    {
        // we clear old player list
        heroesInBattle.Clear();


        foreach (var item in _heroes)
        {
            // shape check
            ShapeCheck(item);  


            heroesInBattle.Add(item.Key, playerSO);

            print(heroesInBattle[item.Key].GO.name);
            print(heroesInBattle[item.Key].AP);
        }
        
    }

    // this is not workind
    private void ShapeCheck(KeyValuePair<int, Hero> item)
    {
        // we will assign value to GAmeobject;


        playerSO.GO = playerGO;
        playerSO.AP = 1;
        //if (item.Value.shapeType == ShapeTypes.Circle)
        //{
        //    playerGO.GO = Resources.Load<GameObject>("GameObjects/Circle");
        //    playerGO.GO.name = "circle";
        //}

        //else if (item.Value.shapeType == ShapeTypes.Square)
        //{
        //    playerGO.GO = Resources.Load<GameObject>("GameObjects/Square");
        //    playerGO.GO.name = "square";
        //}
    }
}
