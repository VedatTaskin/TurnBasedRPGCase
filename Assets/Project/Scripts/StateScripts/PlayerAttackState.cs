using UnityEngine;

public class PlayerAttackState : BaseState
{
    public override void EnterState(StateManager stateM)
    {
        EventManager.onStateChange?.Invoke(stateM.playerAttackState);
    }


    public override void UpdateState(StateManager stateM)
    {
        
    }

    public override void OnTriggerEnter2D(StateManager stateM, Collider2D collider2D)
    {

        IDamagable damagable = collider2D.gameObject.GetComponent<IDamagable>();

        if (damagable != null && collider2D.CompareTag("Enemy"))
        {            

            if (stateM.gameObject.TryGetComponent(out PlayerControl playerControl))
            {
                damagable.TakeDamage(playerControl.AP);
            }            

        }
    }


}
