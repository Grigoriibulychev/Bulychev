using System.Resources;
using UnityEngine;

public class BossDeathState : AbstractBossState
{
    public override void OnEnterState(BossState State)
    {
        State.SetSpeed(0);
        State.animator.SetBool("Death", true);
    }

    public override void OnExitState(BossState State)
    {
    }

    public override void UpdateState(BossState State)
    {

    }
}
