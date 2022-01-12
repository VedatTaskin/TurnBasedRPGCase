using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class PlayerControl : DefaultCharacterControl
{
    public override void Start()
    {
        base.Start();
        text.text = gameObject.name;
        sliderMaxValue = HP;
    }

    public override void Die()
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

    public override void OnTriggerEnter2D(Collider2D collider2D)
    {
        IDamagable damagable = collider2D.gameObject.GetComponent<IDamagable>();

        if (damagable != null && currentState.GetType() == playerAttackState.GetType())
        {
            damagable.TakeDamage(AP);

            if (boxCollider2D.isActiveAndEnabled)
            {
                StartCoroutine(CloseColliderLittleTime(1.5f));
            }
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
