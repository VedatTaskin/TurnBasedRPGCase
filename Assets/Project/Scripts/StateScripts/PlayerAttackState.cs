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
}
