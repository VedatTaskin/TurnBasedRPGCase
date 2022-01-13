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
    public override void OnTriggerEnter2D(StateManager stateM, Collider2D collider2D)
    {

    }

}
