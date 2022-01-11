using UnityEngine;

public class PlayerAttackState : BaseState
{
    public override void EnterState(StateManager stateM)
    {
        Debug.Log("a player start to attack");
        EventManager.onStateChange?.Invoke(stateM.playerAttackState);
    }

    public override void OnCollisionEnter2D(StateManager stateM, Collision2D collision2D)
    {
        IDamagable damagable = collision2D.gameObject.GetComponent<IDamagable>();

        if (damagable != null)
        {
            damagable.TakeDamage(10);
        }

        Debug.Log("there is col");

    }

    public override void UpdateState(StateManager stateM)
    {

    }
}
