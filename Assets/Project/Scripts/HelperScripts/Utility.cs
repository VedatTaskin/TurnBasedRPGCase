using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Utility : MonoBehaviour
{

    // this is for choosing a random Enum (Generic type)
    // Taken from: https://answers.unity.com/questions/810638/using-randomrange-to-pick-a-random-value-out-of-an.html
    public static T RandomEnumValue<T>()
    {
        var values = Enum.GetValues(typeof(T));
        int random = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(random);
    }

}
