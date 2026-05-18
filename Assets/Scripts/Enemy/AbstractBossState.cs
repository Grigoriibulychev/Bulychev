using UnityEngine;

public abstract class AbstractBossState : MonoBehaviour
{
    abstract public void OnEnterState(BossState State);

    abstract public void OnExitState(BossState State);

    abstract public void UpdateState(BossState State);
}
