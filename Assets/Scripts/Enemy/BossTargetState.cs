using UnityEngine;

public class BossTargetState : AbstractBossState
{
    public override void OnEnterState(BossState State)
    {
        State.animator.SetBool("Rage", true);
    }

    public override void OnExitState(BossState State)
    {
        State.animator.SetBool("Target", false);
        State.animator.SetBool("Rage", false);
    }

    public override void UpdateState(BossState State)
    {
        State.BossNavMeshAgent.destination = State.Player.position;
        if (State.DistanceToTarget()<3.5f)
        {
            State.SwitchState(State.BossAttackState);
            return;
        }
    }
}
