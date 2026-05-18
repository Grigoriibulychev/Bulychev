using Unity.VisualScripting;
using UnityEngine;

public class BossIdleState : AbstractBossState
{
    public override void OnEnterState(BossState State)
    {
        State.SetSpeed(0);
        State.animator.SetBool("Idle", true);     
    }

    public override void OnExitState(BossState State) 
    {
        State.animator.SetBool("Idle", false);
    }

    public override void UpdateState(BossState State)
    {
    }
}
