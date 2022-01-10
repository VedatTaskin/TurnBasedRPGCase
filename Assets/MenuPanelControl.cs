using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuPanelControl : MonoBehaviour
{
    Vector2 startPosition;

    private void OnEnable()
    {
        EventManager.isBattleStarted += IsBattleStarted;
    }

    private void OnDisable()
    {
        EventManager.isBattleStarted -= IsBattleStarted;
    }

    private void IsBattleStarted(bool obj)
    {

    }

}
