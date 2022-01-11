using UnityEngine;

public class PlayerAttackState : BaseState
{
    public override void EnterState(StateManager stateM)
    {
        Debug.Log("a player start to attack");
        EventManager.onStateChange?.Invoke(stateM.playerAttackState);
    }

    public override void OnCollisionEnter(StateManager stateM, Collision collision)
    {

    }

    public override void UpdateState(StateManager stateM)
    {

    }
}
