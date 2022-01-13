using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Hero list taken and "players" are preparing
public class BattlePreparation : MonoBehaviour
{
    List<Hero> heroes = new List<Hero>();   //all heroes in our list
    public GameObject defaultPlayerGO; // default gameobject will modify according to shape, size, color   
    public GameObject enemy;
    float offsetY = 3.5f;


    private void OnEnable()
    {
        EventManager.heroesAreChosenForBattle += CreateCharacters;
        enemy.SetActive(false);
    }

    private void OnDisable()
    {
        EventManager.heroesAreChosenForBattle -= CreateCharacters;
    }

    private void Start()
    {
        // we take the hero list that created
        heroes = GameObject.FindObjectOfType<HeroPreparation>().heroes;
    }
    // player features are defining;
    private void CreateCharacters(Dictionary<int, Hero> _heroes)
    {
        CreatePlayers(_heroes);
        CreateEnemy();
    }

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
    }

    //we shape enemy randomly 
    private void CreateEnemy()
    {
        enemy.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f); // we need this to set default scale  when activate and deactivate enemy
        enemy.GetComponent<SpriteRenderer>().material = heroes[UnityEngine.Random.Range(0, heroes.Count)].material;
        enemy.GetComponent<SpriteRenderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f),UnityEngine.Random.Range(0f, 1f),UnityEngine.Random.Range(0f, 1f));
        enemy.GetComponent<SpriteRenderer>().sprite = heroes[UnityEngine.Random.Range(0, heroes.Count)].sprite;
        enemy.GetComponent<Transform>().localScale *= (int) heroes[UnityEngine.Random.Range(0, heroes.Count)].sizeType;
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
