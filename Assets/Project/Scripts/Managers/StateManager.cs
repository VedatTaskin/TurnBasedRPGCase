using UnityEngine;
using UnityEngine.EventSystems;

public class StateManager : MonoBehaviour
{

    #region States
    public BaseState currentState;
    public PlayerTurnState playerTurnState = new PlayerTurnState();
    public PlayerAttackState playerAttackState = new PlayerAttackState();    
    public EnemyTurnState enemyTurnState = new EnemyTurnState();
    public EnemyAttackState enemyAttackState = new EnemyAttackState();
    public GameFinishState gameFinishState = new GameFinishState();
    #endregion

    public virtual void OnEnable()
    {
        EventManager.onStateChange += OnStateChanged;
    }

    public virtual void OnDisable()
    {
        EventManager.onStateChange -= OnStateChanged;
    }

    public virtual void Start()
    {
        currentState = playerTurnState;
    }

    public virtual void SwitchState(BaseState baseState)
    {
        currentState = baseState;
        currentState.EnterState(this);
    }

    public virtual void OnStateChanged(BaseState baseState)
    {
        currentState = baseState;
    }

    public virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        currentState.OnTriggerEnter2D(this, collider2D);
    }
}
