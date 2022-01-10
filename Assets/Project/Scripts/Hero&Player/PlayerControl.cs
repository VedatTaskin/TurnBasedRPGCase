using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    Slider slider;
    Text text;
    

    [HideInInspector] public int AP;
    [HideInInspector] public int HP;
    private int sliderMaxValue;


    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<Text>();
        //sliderMaxValue = HP;
        //slider.value = HP / sliderMaxValue;
        text.text = gameObject.name;
    }

    private void OnEnable()
    {
        EventManager.OnMenuActive += ReturnToMenu;
    }

    private void OnDisable()
    {
        EventManager.OnMenuActive -= ReturnToMenu;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Die();
        }

        slider.value = HP/sliderMaxValue;
    }

    private void Die()
    {
        print("we died");
    }

    void ReturnToMenu()
    {
        Destroy(gameObject);
    }
}
