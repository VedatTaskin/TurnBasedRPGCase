using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static Action<int> addHero;
    public static Action<int> removeHero;
    public static Action<int> chosenHeroCount;
}
