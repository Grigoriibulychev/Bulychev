using UnityEngine;

public class BossAttackState : AbstractBossState
{
    public override void OnEnterState(BossState State)
    {
        State.SetSpeed(0);
        State.animator.SetBool("Attack", true);
    }

    public override void OnExitState(BossState State)
    {
        State.animator.SetBool("Attack", false);
    }

    public override void UpdateState(BossState State)
    {
        if (State.RotateAccess == true)
        {
            Vector3 DirectionToTarget = (State.Player.position - State.transform.position).normalized;
            Quaternion Rotate = Quaternion.LookRotation(DirectionToTarget);
            State.transform.rotation = Quaternion.Slerp(State.transform.rotation, Rotate, Time.deltaTime * 3.0F);
        }
    }
}
