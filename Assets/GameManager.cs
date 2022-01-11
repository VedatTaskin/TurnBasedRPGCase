using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    Dictionary<string, GameObject> playersInGame = new Dictionary<string, GameObject>();
    private void OnEnable()
    {
        EventManager.players += OnPlayerCreated;
        EventManager.OnMenuActive += OnMenuActive;
    }

    private void OnDisable()
    {
        EventManager.players -= OnPlayerCreated;
        EventManager.OnMenuActive -= OnMenuActive;
    }

    private void OnMenuActive()
    {
        playersInGame.Clear();
    }

    private void OnPlayerCreated(GameObject obj)
    {
        playersInGame.Add(obj.name, obj);
    }
}
