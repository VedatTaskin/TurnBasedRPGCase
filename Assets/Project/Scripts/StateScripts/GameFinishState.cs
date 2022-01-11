using UnityEngine;

public class GameFinishState : BaseState
{
    public override void EnterState(StateManager stateM)
    {
        EventManager.onStateChange?.Invoke(stateM.gameFinishState);
    }


    public override void UpdateState(StateManager stateM)
    {

    }

}
