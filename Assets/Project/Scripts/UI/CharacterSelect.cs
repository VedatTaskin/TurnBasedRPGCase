using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CharacterSelect : MonoBehaviour, IPointerClickHandler
{
    Image image;
    bool isSelected =false;
    int chosenHeroCount; // we listen MenuControl for chosen player count
    int maxHeroCount;  // we take this value from MenuControl


    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }

    private void OnEnable()
    {
        EventManager.chosenHeroCount += ChosenHeroCount;
        EventManager.playerCountInGame += SetMaxHeroCount; 
    }

    private void OnDisable()
    {
        EventManager.chosenHeroCount -= ChosenHeroCount;
        EventManager.playerCountInGame -= SetMaxHeroCount;

        OnCardDisable();
    }

    //we check if this card clicked, and then we invoke an event and send card index - MenuControl listening us
    // we can't select any player if we reach maxHeroCount 
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isSelected && chosenHeroCount < maxHeroCount)
        {
            image.color = Color.blue;
            isSelected = true;
            EventManager.addHero?.Invoke(transform.GetSiblingIndex());
        }

        else if (isSelected)
        {
            image.color = Color.white;
            isSelected = false;
            EventManager.removeHero?.Invoke(transform.GetSiblingIndex());
        }
    }

    //to hold the count of heroes that selected 
    private void ChosenHeroCount(int count)
    {
        chosenHeroCount = count;
    }

    // we set card to the default state     
    public void OnCardDisable()
    {
        isSelected = false;
        image.color = Color.white;
        chosenHeroCount = 0;
    }

    private void SetMaxHeroCount(int count)
    {
        maxHeroCount = count;
    }
}
