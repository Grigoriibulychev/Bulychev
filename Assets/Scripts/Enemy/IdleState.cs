using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class IdleState : AbstractState
{
    public override void EnterState(EnemyStateManager State)
    {
        State.SetSpeed(0);
    }
    public override void ExitState(EnemyStateManager State) 
    {
        //Debug.Log("Exit Idle");
        State.Animator.SetBool("Idle", false);
    }

    public override void UpdateState(EnemyStateManager State)
    {
        if (State.DistanceToTarget() <= State.TargetingDistance)
        {
            State.EnemyNavMeshAgent.destination = State.Target.position;
            State.EnemyNavMeshAgent.speed = 0.08F;
            State.Animator.SetBool("Scream", true);
            return;
        }
    }
}
