using UnityEngine;

public abstract class BaseState 
{
    public abstract void EnterState(StateManager stateM);

    public abstract void UpdateState(StateManager stateM);

    public abstract void OnCollisionEnter(StateManager stateM, Collision collision);

}
