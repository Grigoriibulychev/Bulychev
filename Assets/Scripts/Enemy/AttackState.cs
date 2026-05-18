using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackState : AbstractState
{
    public override void EnterState(EnemyStateManager State)
    {
        State.SetSpeed(0);
        State.Animator.SetBool("Combo", false);
        State.AttackCount = 0;
    }
    public override void ExitState(EnemyStateManager State)
    {
        //Debug.Log("Exit Attack");
        State.Animator.SetBool("Attack", false);
    }

    public override void UpdateState(EnemyStateManager State)
    {
        if (State.RotateAcess == true)
        {
            Vector3 DirectionToTarget = (State.Target.position - State.transform.position).normalized;
            Quaternion Rotate = Quaternion.LookRotation(DirectionToTarget);
            State.transform.rotation = Quaternion.Slerp(State.transform.rotation, Rotate, Time.deltaTime * 2.0F);
        }
        if (State.AttackCount>=2)
        {
            State.Animator.SetBool("Combo", true);
            State.Animator.SetBool("Attack", false);
        }
    }
}
