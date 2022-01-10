using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject menuControl;
    public Button battleStartButton;
    public Button returnButton;


    private void Awake()
    {
        Restart();
    }

    private void OnEnable()
    {
        EventManager.chosenHeroCount += ChosenHeroCount;
    }


    private void OnDisable()
    {
        EventManager.chosenHeroCount -= ChosenHeroCount;
    }

    // to activate start button we check chosen hero count
    private void ChosenHeroCount(int count)
    {
        if (count == menuControl.GetComponent<MenuControl>().heroCountInGame)
        {
            battleStartButton.gameObject.SetActive(true);
        }
        else
        {
            battleStartButton.gameObject.SetActive(false);
        }
    }

    // if start button clicked we close menu and start button
    public void BattleStart()
    {
        menuControl.SetActive(false);
        battleStartButton.gameObject.SetActive(false);
        OnGameFinished();
    }

    public void Restart()
    {
        menuControl.SetActive(true);
        battleStartButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);

    }

    public void OnGameFinished()
    {
        returnButton.gameObject.SetActive(true);
    }
}
