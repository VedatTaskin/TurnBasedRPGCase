using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour, IPointerClickHandler
{
    Slider slider;
    int sliderMaxValue;
    Text text;    

    [HideInInspector] public int AP;
    [HideInInspector] public int HP;

    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<Text>();
        sliderMaxValue = HP;
        slider.value = HP / sliderMaxValue;
        text.text = gameObject.name;
    }

    private void OnEnable()
    {
        EventManager.onMenuActive += ReturnToMenu;
    }

    private void OnDisable()
    {
        EventManager.onMenuActive -= ReturnToMenu;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Die();
        }

        slider.value = (float) HP/sliderMaxValue;
    }

    private void Die()
    {        
        EventManager.onPlayerDied?.Invoke(gameObject);
        Destroy(gameObject);
    }

    void ReturnToMenu()
    {
        Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print(gameObject.name);
        TakeDamage(50);
    }
}
