using UnityEngine;

public class DeathState : AbstractState
{
    public override void EnterState(EnemyStateManager State)
    {
        State.SetSpeed(0);
        State.Damageble=false;
        State.Animator.SetBool("GetDamaged", false);
    }

    public override void ExitState(EnemyStateManager State)
    {

    }

    public override void UpdateState(EnemyStateManager State)
    {
        
    }
}
