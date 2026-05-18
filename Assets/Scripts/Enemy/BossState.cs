using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BossState : MonoBehaviour
{
    internal BossIdleState BossIdleState=new BossIdleState();
    internal BossTargetState BossTargetState=new BossTargetState();
    internal BossDeathState BossDeathState=new BossDeathState();
    internal BossAttackState BossAttackState = new BossAttackState();
    internal AbstractBossState BossCurrentState;
    [SerializeField] public Transform Player;
    [SerializeField] public NavMeshAgent BossNavMeshAgent;
    [SerializeField] public Animator animator;
    public bool FirstSwap=true;
    public GameObject AttackZone;
    internal bool RotateAccess;
    public int DeathCount;
    private void Start()
    {
        DeathCount = 0;
        SwitchState(BossIdleState);
        FirstSwap = false;
    }
    public void SetSpeed(float speed)
    {
        BossNavMeshAgent.speed = speed;
    }
    public void SetTarget(Transform Target)
    {
        BossNavMeshAgent.destination=Target.position;
    }

    public void SwitchState(AbstractBossState NewState)
    {
        if (FirstSwap==false)
        {
            BossCurrentState.OnExitState(this);
        }
        BossCurrentState=NewState;
        BossCurrentState.OnEnterState(this);
    }
    public void Update()
    {
        BossCurrentState.UpdateState(this);
    }

    public float DistanceToTarget()
    {
        return (Player.position-transform.position).magnitude;
    }

    public void RageStart()
    {
        SetSpeed(0);
    }

    public void RageEnd()
    {
        if (BossCurrentState == BossTargetState)
        {
            animator.SetBool("Target",true);
            SetSpeed(2.75f);
        }
    }

    public void RotateFalse()
    {
        RotateAccess = false;
    }
    public void AttackStart()
    {
        AttackZone.SetActive(true);
    }
    public void AttackEnd()
    {
        AttackZone.SetActive(false);
        RotateAccess = true;
        if (DistanceToTarget()>3.5f)
        {
            SetSpeed(2.75f);
            animator.SetBool("Target", true);
            SwitchState(BossTargetState);
        }
    }

    public void Death()
    {
        animator.SetBool("Death", false);
    }

    public void TrueDeath()
    {
        this.gameObject.SetActive(false);
    }
}
