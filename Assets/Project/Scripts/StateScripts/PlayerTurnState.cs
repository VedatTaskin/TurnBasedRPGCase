using UnityEngine;

public class PlayerTurnState : BaseState
{
    public override void EnterState(StateManager stateM)
    {

    }

    public override void OnCollisionEnter2D(StateManager stateM, Collision2D collision2D)
    {

    }

    public override void UpdateState(StateManager stateM)
    {
        Debug.Log("hi playerturn update");
    }

}
