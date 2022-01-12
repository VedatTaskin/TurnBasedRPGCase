using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    Dictionary<string, GameObject> playersInGame = new Dictionary<string, GameObject>();
    private void OnEnable()
    {
        EventManager.onPlayerCreated += OnPlayerCreated;
        EventManager.onMenuActive += OnMenuActive;
        EventManager.onPlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        EventManager.onPlayerCreated -= OnPlayerCreated;
        EventManager.onMenuActive -= OnMenuActive;
        EventManager.onPlayerDied -= OnPlayerDied;
    }

    private void OnPlayerDied(GameObject obj)
    {
        playersInGame.Remove(obj.name);

        if (playersInGame.Count<=0)
        {
            EventManager.playerLostGame?.Invoke();
        }
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
