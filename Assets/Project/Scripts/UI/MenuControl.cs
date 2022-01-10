using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{

    List<Hero> heroes = new List<Hero>();   //all heroes in our list
    List<GameObject> heroCards = new List<GameObject>(); // This Cards will show on UI
    Dictionary<int, Hero> chosenHeroes = new Dictionary<int, Hero>();   


    public GameObject cardPrefab;
    public int heroCountInGame = 3;


    private void OnEnable()
    {
        EventManager.addHero += AddHero;
        EventManager.removeHero += RemoveHero;     
       
    }

    private void OnDisable()
    {
        EventManager.addHero -= AddHero;
        EventManager.removeHero -= RemoveHero;

        OnMenuDisable();
    }

    // creating cards according to heroes in the list
    private void Start()
    {

        // we take the hero list that created
        heroes= GameObject.FindObjectOfType<HeroStatCalculator>().heroes;

        for (int i = 0; i < heroes.Count; i++)
        {         
            //Instantiating cards according the hero count
            Instantiate(cardPrefab, transform);
            heroCards.Add(cardPrefab);
        }

        SetCardInfo();
    }

    // assiging card values 
    void SetCardInfo()
    {
        // this part depends on card template
        for (int i = 0; i < heroCards.Count; i++)
        {
            transform.GetChild(i).name= heroes[i].Name;
            transform.GetChild(i).GetChild(0).GetComponent<Text>().text = heroes[i].Name;
            transform.GetChild(i).GetChild(1).GetComponent<Text>().text = heroes[i].HP.ToString();
            transform.GetChild(i).GetChild(2).GetComponent<Text>().text = heroes[i].AP.ToString();
        }
    }

    //Adding a hero into chosenList
    private void AddHero(int index)
    {
        if (chosenHeroes.Count< heroCountInGame)
        {
            chosenHeroes.Add(index, heroes[index]);
            EventManager.chosenHeroCount?.Invoke(chosenHeroes.Count);            
        }
    }

    //Removing a hero from chosenList
    private void RemoveHero(int index)
    {
        if (chosenHeroes.ContainsKey(index))
        {
            chosenHeroes.Remove(index);
            EventManager.chosenHeroCount?.Invoke(chosenHeroes.Count);
        }        
    }
    
    private void OnMenuDisable()
    {
        // we send chosenHero list to others;
        EventManager.chosenHeroesForBattle?.Invoke(chosenHeroes);

        // we clear chosen hero list
        chosenHeroes.Clear();         

    }

}
