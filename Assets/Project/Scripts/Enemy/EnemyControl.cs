using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;


public class EnemyControl : StateManager,IDamagable
{
    Slider slider;
    int sliderMaxValue;
    Text text;
    GameObject targetGO;  // temporary target
    int HP;
    int AP;

    public override void OnEnable()
    {
        base.OnEnable();
        SetEnemySliderAndText();
        EventManager.playerLostGame += PlayerLostGame;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        EventManager.playerLostGame -= PlayerLostGame;
    }
     
    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Die();
        }

        slider.value = (float)HP / sliderMaxValue;

        transform.DOShakePosition(0.5f, 1, 10, 90); // we give some shake
    }

    private void Die()
    {
        EventManager.playerWinGame?.Invoke();
        SwitchState(gameFinishState);
        gameObject.SetActive(false);
    }

    void MoveEnemy()
    {
        Vector3 target= FindRandomEnemy();
        transform.DOMove(target, 1).SetEase(Ease.OutCubic).SetLoops(2, LoopType.Yoyo).
            OnComplete(() => SwitchState(playerTurnState));
    }

    private void SetEnemySliderAndText()
    {
        // we set defaultenemy HP and AP
        HP = UnityEngine.Random.Range(400, 800);
        AP = UnityEngine.Random.Range(30, 50);
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<Text>();
        sliderMaxValue = HP;
        slider.value = (float) HP / sliderMaxValue;
        text.text = "Enemy";
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

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        IDamagable damagable = collider2D.gameObject.GetComponent<IDamagable>();

        if (damagable != null && currentState.GetType() == enemyAttackState.GetType() && targetGO.name ==collider2D.name)
        {
            damagable.TakeDamage(AP);
        }
    }

    public Vector3 FindRandomEnemy()
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


}
