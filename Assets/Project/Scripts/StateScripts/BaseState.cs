using UnityEngine;

public abstract class BaseState 
{
    public abstract void EnterState(StateManager stateM);

    public abstract void UpdateState(StateManager stateM);

    public abstract void OnTriggerEnter2D(StateManager stateM,  Collider2D collider2D);

}
