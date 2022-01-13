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

    public override void OnTriggerEnter2D(StateManager stateM, Collider2D collider2D)
    {

    }

}
