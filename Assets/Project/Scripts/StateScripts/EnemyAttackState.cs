using UnityEngine;

public class EnemyAttackState : BaseState
{
    public override void EnterState(StateManager stateM)
    {
        EventManager.onStateChange?.Invoke(stateM.enemyAttackState);
    }

    public override void UpdateState(StateManager stateM)
    {

    }

    public override void OnTriggerEnter2D(StateManager stateM, Collider2D collider2D)
    {

        IDamagable damagable = collider2D.gameObject.GetComponent<IDamagable>();

        if (damagable != null && collider2D.CompareTag("Player"))
        {
            if (stateM.gameObject.TryGetComponent(out EnemyControl enemyControl))
            {
                // check for the collision with our target, may be we hit accidentally a player in our way
                if (enemyControl.targetGO.name==collider2D.gameObject.name) 
                {
                    damagable.TakeDamage(enemyControl.AP);
                }                
            }

        }

    }
}