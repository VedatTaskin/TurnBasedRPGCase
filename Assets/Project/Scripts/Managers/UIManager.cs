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
    int maxHeroCount;


    private void Awake()
    {
        Restart();
    }

    private void OnEnable()
    {
        EventManager.chosenHeroCount += ChosenHeroCount;
        EventManager.playerCountInGame += SetMaxHeroCount;
        EventManager.onBattleFinished += OnBattleFinished;
    }

    private void OnDisable()
    {
        EventManager.chosenHeroCount -= ChosenHeroCount;
        EventManager.playerCountInGame -= SetMaxHeroCount;
        EventManager.onBattleFinished -= OnBattleFinished;
    }

    private void SetMaxHeroCount(int count)
    {
        maxHeroCount = count;
    }

    // to activate start button we check chosen hero count
    private void ChosenHeroCount(int count)
    {
        if (count == maxHeroCount)
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
    }

    public void Restart()
    {
        menuControl.SetActive(true);
        battleStartButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        EventManager.onMenuActive?.Invoke();
    }

    public void OnBattleFinished()
    {
        returnButton.gameObject.SetActive(true);
    }
}
