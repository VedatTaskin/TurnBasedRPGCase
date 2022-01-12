﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;


public class EnemyControl : DefaultCharacterControl
{
    GameObject targetGO;  // temporary target

    public override void OnEnable()
    {
        base.OnEnable();
        EventManager.playerLostGame += PlayerLostGame;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        EventManager.playerLostGame -= PlayerLostGame;
    }

    public override void Die()
    {
        EventManager.playerWinGame?.Invoke();
        SwitchState(gameFinishState);
        gameObject.SetActive(false);
    }

    void MoveEnemy()
    {
        Vector3 target= FindRandomPlayerTarget();
        transform.DOMove(target, 1).SetEase(Ease.OutCubic).SetLoops(2, LoopType.Yoyo).
            OnComplete(() => SwitchState(playerTurnState));
    }

    public override void SetSliderAndText()
    {
        // we set defaultenemy HP and AP
        HP = 100;  //UnityEngine.Random.Range(400, 800);
        AP = 20; // UnityEngine.Random.Range(30, 50);
        base.SetSliderAndText();
    }

    public override void OnStateChanged(BaseState baseState)
    {
        base.OnStateChanged(baseState);

        //I spend some time on this, the if statement didn't work without ".GetType" :( 
        if (currentState.GetType() == enemyTurnState.GetType())
        {
            MoveEnemy();

            SwitchState(enemyAttackState);
        }

        if (currentState.GetType()==gameFinishState.GetType())
        {
            gameObject.SetActive(false);
        }

    }

    public Vector3 FindRandomPlayerTarget()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        //print(gos.Length);
        targetGO = gos[Random.Range(0, gos.Length)];
        return targetGO.transform.position;
    }

    private void PlayerLostGame()
    {
        SwitchState(gameFinishState);
        gameObject.SetActive(false);
    }

    public override void OnTriggerEnter2D(Collider2D collider2D)
    {
        IDamagable damagable = collider2D.gameObject.GetComponent<IDamagable>();

        if (damagable != null && currentState.GetType() == enemyAttackState.GetType() && targetGO.name == collider2D.name)
        {
            damagable.TakeDamage(AP);

            if (boxCollider2D.isActiveAndEnabled)
            {
                StartCoroutine(CloseColliderLittleTime(1.5f));
            }
        }
    }

}