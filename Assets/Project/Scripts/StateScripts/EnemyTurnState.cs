using UnityEngine;

public class EnemyTurnState : BaseState
{
    public override void EnterState(StateManager stateM)
    {
        Debug.Log("enemy trun state");
    }

    public override void OnCollisionEnter(StateManager stateM, Collision collision)
    {
        
    }

    public override void UpdateState(StateManager stateM)
    {

    }
}
