using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuControl;
    public Button battleStartButton;
    public Button restartButton;


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
    public void OnBattleStart()
    {
        menuControl.SetActive(false);
        battleStartButton.gameObject.SetActive(false);
        OnGameFinished();
    }

    public void Restart()
    {
        menuControl.SetActive(true);
        battleStartButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

    }

    public void OnGameFinished()
    {
        restartButton.gameObject.SetActive(true);
        EventManager.onReturnHeroSelectionScene?.Invoke();
    }
}
