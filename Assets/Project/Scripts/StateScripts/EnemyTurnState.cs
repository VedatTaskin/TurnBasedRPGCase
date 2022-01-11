using UnityEngine;

public class EnemyTurnState : BaseState
{
    public override void EnterState(StateManager stateM)
    {
        EventManager.onStateChange?.Invoke(stateM.enemyTurnState);
    }

    public override void UpdateState(StateManager stateM)
    {

    }
}
