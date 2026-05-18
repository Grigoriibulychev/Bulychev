using UnityEngine;

public class TargetingState : AbstractState
{
    public override void EnterState(EnemyStateManager State)
    {
        Debug.Log("speed changed");
        State.SetSpeed(State.TargetSpeed);
    }
    public override void ExitState(EnemyStateManager State)
    {
        //Debug.Log("Exit Targeting");
        State.Animator.SetBool("Run", false);
    }

    public override void UpdateState(EnemyStateManager State)
    {


        if (State.DistanceToTarget() <= State.AttackingDistance) 
        {
            State.SwitchState(State.AttackState);
            State.Animator.SetBool("Attack", true);
            return;
        }
        if (State.DistanceToTarget() > State.TargetingDistance)
        {
            State.SwitchState(State.IdleState);
            State.Animator.SetBool("Idle", true);
            return;
        }
        State.EnemyNavMeshAgent.destination = State.Target.position;
    }
}
