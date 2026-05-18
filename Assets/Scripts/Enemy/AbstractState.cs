using UnityEngine;

public abstract class AbstractState : MonoBehaviour
{
    public abstract void EnterState(EnemyStateManager State);
    public abstract void ExitState(EnemyStateManager State);
    public abstract void UpdateState(EnemyStateManager State);
}
