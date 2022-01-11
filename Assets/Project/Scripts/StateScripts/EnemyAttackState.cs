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
}