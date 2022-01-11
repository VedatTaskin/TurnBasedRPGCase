using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerControl : StateManager
{
    Slider slider;
    int sliderMaxValue;
    Text text;    

    [HideInInspector] public int AP;
    [HideInInspector] public int HP;

    public override void OnEnable()
    {
        base.OnEnable();
        EventManager.onMenuActive += ReturnToMenu;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        EventManager.onMenuActive -= ReturnToMenu;
    }

    public override void Start()
    {
        base.Start();
        SetPlayerSliderAndText();
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

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (currentState==playerTurnState)
        {
            SwitchState(playerAttackState);
        }

    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }

    void SetPlayerSliderAndText()
    {
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<Text>();
        sliderMaxValue = HP;
        slider.value = HP / sliderMaxValue;
        text.text = gameObject.name;
    }

}
