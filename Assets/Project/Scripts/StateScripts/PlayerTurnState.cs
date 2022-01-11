using UnityEngine;

public class PlayerTurnState : BaseState
{
    public override void EnterState(StateManager stateM)
    {
        EventManager.onStateChange?.Invoke(stateM.playerTurnState);
    }


    public override void UpdateState(StateManager stateM)
    {
        
    }

}
