using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class PlayerControl : StateManager,IDamagable
{
    Slider slider;
    int sliderMaxValue;
    Text text;    

    [HideInInspector] public int AP;
    [HideInInspector] public int HP;

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
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

    public override void OnPointerClick(PointerEventData eventData)
    {

        if (currentState.GetType() ==playerTurnState.GetType())
        {
            SwitchState(playerAttackState);

            MovePlayer();
        }
    }

    void MovePlayer()
    {
        var pos= GameObject.FindGameObjectWithTag("Enemy").transform.position;
        transform.DOMove(pos, 1).SetEase(Ease.OutCubic).SetLoops(2,LoopType.Yoyo).OnComplete(() => SwitchState(enemyTurnState));        
    }

    void SetPlayerSliderAndText()
    {
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<Text>();
        sliderMaxValue = HP;
        slider.value = HP / sliderMaxValue;
        text.text = gameObject.name;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        IDamagable damagable = collider2D.gameObject.GetComponent<IDamagable>();

        if (damagable != null && currentState.GetType() == playerAttackState.GetType())
        {
            damagable.TakeDamage(AP);
        }
    }

    public override void OnStateChanged(BaseState baseState)
    {
        base.OnStateChanged(baseState);

        if (currentState.GetType() == gameFinishState.GetType())
        {
            Destroy(gameObject);
        }

    }


}
