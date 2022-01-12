using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    
    public static Action<int> addHero;  // index of hero sends to add list    
    public static Action<int> removeHero; // index of hero sends to remove from list
    public static Action<int> chosenHeroCount;
    public static Action<Dictionary<int, Hero>> heroesAreChosenForBattle;
    public static Action<GameObject> onPlayerCreated;
    public static Action<int> playerCountInGame;
    public static Action onMenuActive;
    public static Action<GameObject> onPlayerDied;
    public static Action playerLostGame;
    public static Action playerWinGame;
    public static Action<BaseState> onStateChange;
 
}
