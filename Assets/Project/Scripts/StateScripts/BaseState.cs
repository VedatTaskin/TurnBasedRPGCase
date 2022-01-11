using UnityEngine;

public abstract class BaseState 
{
    public abstract void EnterState(StateManager stateM);

    public abstract void UpdateState(StateManager stateM);

}
