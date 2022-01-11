using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StateManager : MonoBehaviour, IPointerClickHandler
{

    #region States
    public BaseState currentState;
    public BattleStartState battleStartState = new BattleStartState();
    public PlayerTurnState playerTurnState = new PlayerTurnState();
    public PlayerAttackState playerAttackState = new PlayerAttackState();    
    public EnemyTurnState enemyTurnState = new EnemyTurnState();
    public EnemyAttackState enemyAttackState = new EnemyAttackState();
    public WinState winState = new WinState();
    public LostState lostState = new LostState();
    #endregion

    public virtual void OnEnable()
    {
        EventManager.onStateChange += OnStateChanged;
    }

    public virtual void OnDisable()
    {
        EventManager.onStateChange -= OnStateChanged;
    }

    public virtual void Start()
    {
        currentState = playerTurnState;
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    public virtual void OnPointerClick(PointerEventData eventData) 
    {
    }

    public virtual void SwitchState(BaseState baseState)
    {
        currentState = baseState;
        currentState.EnterState(this);
    }

    public virtual void OnStateChanged(BaseState baseState)
    {
        currentState = baseState;
    }
}
