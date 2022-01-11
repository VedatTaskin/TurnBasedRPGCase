using UnityEngine;

public class EnemyTurnState : BaseState
{
    public override void EnterState(StateManager stateM)
    {
        Debug.Log("enemy trun state");
    }

    public override void OnCollisionEnter2D(StateManager stateM, Collision2D collision2D)
    {
        
    }

    public override void UpdateState(StateManager stateM)
    {

    }
}
