using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] public Collider RightAttackLimb;

    [SerializeField] public Collider LeftAttackLimb;

    internal bool Damageble=true;

    internal int Hit;

    public Transform Target;

    internal int AttackCount = 0;

    internal bool RotateAcess;

    bool startstate;

    AbstractState CurrentState;

    public float TargetingDistance=10;

    public float AttackingDistance=1;

    internal IdleState IdleState=new IdleState();

    internal TargetingState TargetingState=new TargetingState();

    internal AttackState AttackState=new AttackState();

    internal DeathState DeathState=new DeathState();
    
    [SerializeField] internal NavMeshAgent EnemyNavMeshAgent;

    [SerializeField] public Animator Animator;

    [SerializeField] public float TargetSpeed;

    public void SwitchState(AbstractState State)
    {
        if (/*CurrentState != null*/ !startstate) 
        {
            //Debug.Log("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
            CurrentState.ExitState(this);
        }
        else
        {
            //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        }
        CurrentState = State;
        startstate = false;
        CurrentState.EnterState(this);



    }

    private void Start()
    {
        startstate = true;
        SwitchState(IdleState);
        this.GetComponent<Animator>().SetBool("Idle", true);
    }

    private void Update()
    {
        CurrentState.UpdateState(this);
        Debug.Log(CurrentState);
    }

    public void SetSpeed(float speed)
    {
        EnemyNavMeshAgent.speed = speed;
    }

    public void SetTarget(Transform target)
    {
        this.Target = target; // Use to realize monster hostility to player AND NPC
    }

    public float DistanceToTarget()
    {
        return (Target.position - this.transform.position).magnitude;
    }

    public void StartRun()
    {
        Animator.SetBool("Scream", false);
        if (DistanceToTarget() <= TargetingDistance)
        {
            SwitchState(TargetingState);
            Animator.SetBool("Run", true);
            return;
        }
        if (DistanceToTarget() > TargetingDistance)
        {
            SwitchState(IdleState);
            Animator.SetBool("Idle", true);
            return;
        }
        if (DistanceToTarget() <= AttackingDistance)
        {
            SwitchState(AttackState);
            Animator.SetBool("Attack", true);
            return;
        }
    }

    public void AttackStart()
    {
        RightAttackLimb.isTrigger = true;
        if(RightAttackLimb.TryGetComponent(out CapsuleCollider AttackZone))
        {
            AttackZone.height += 0.4f;
            AttackZone.radius += 0.3f;
        }
    }

    public void AttackEnd()
    {
        RotateAcess = true;
        if (RightAttackLimb.TryGetComponent(out CapsuleCollider AttackZone))
        {
            AttackZone.height -= 0.4f;
            AttackZone.radius -= 0.3f;
        }
        RightAttackLimb.isTrigger = false;
        if (DistanceToTarget()>AttackingDistance)
        {
            SwitchState(TargetingState);
            Animator.SetBool("Run", true);
            Animator.SetBool("Attack", false);
        }
    }

    public void ComboStart()
    {
        LeftAttackLimb.GetComponent<CapsuleCollider>().center =new Vector3(LeftAttackLimb.GetComponent<CapsuleCollider>().center.x-0.1F, LeftAttackLimb.GetComponent<CapsuleCollider>().center.y, LeftAttackLimb.GetComponent<CapsuleCollider>().center.z);
        RightAttackLimb.GetComponent<CapsuleCollider>().center = new Vector3(RightAttackLimb.GetComponent<CapsuleCollider>().center.x + 0.3F, RightAttackLimb.GetComponent<CapsuleCollider>().center.y, RightAttackLimb.GetComponent<CapsuleCollider>().center.z);
        RightAttackLimb.GetComponent<CapsuleCollider>().height += 0.1F;
        LeftAttackLimb.GetComponent<CapsuleCollider>().height += 0.1F;
        RightAttackLimb.isTrigger = true;
        LeftAttackLimb.isTrigger = true;
    }
    public void ComboEnd()
    {
        RightAttackLimb.GetComponent<CapsuleCollider>().height -= 0.1F;
        LeftAttackLimb.GetComponent<CapsuleCollider>().height -= 0.1F;
        LeftAttackLimb.GetComponent<CapsuleCollider>().center = new Vector3(LeftAttackLimb.GetComponent<CapsuleCollider>().center.x + 0.1F, LeftAttackLimb.GetComponent<CapsuleCollider>().center.y, LeftAttackLimb.GetComponent<CapsuleCollider>().center.z);
        RightAttackLimb.GetComponent<CapsuleCollider>().center = new Vector3(RightAttackLimb.GetComponent<CapsuleCollider>().center.x - 0.3F, RightAttackLimb.GetComponent<CapsuleCollider>().center.y, RightAttackLimb.GetComponent<CapsuleCollider>().center.z);
        RightAttackLimb.isTrigger = false;
        LeftAttackLimb.isTrigger = false;
        Animator.SetBool("Combo", false);
        RotateAcess = true;
        if (DistanceToTarget() <= AttackingDistance)
        {
            SwitchState(AttackState);
            Animator.SetBool("Attack", true);
            return;
        }
        if (DistanceToTarget() > AttackingDistance)
        {
            SwitchState(TargetingState);
            Animator.SetBool("Run", true);
            return;
        }
    }

    public void Death()
    {
        Target.gameObject.GetComponent<PlayerParameters>().GunArmor += 8;
        Animator.SetBool("Death", false);
        SwitchState(DeathState);
    }

    public void Disappear()
    {
        this.gameObject.SetActive(false);
    }
    public void RotateEnd()
    {
        RotateAcess=false;
        AttackCount += 1;
    }

    public void GetDamaged()
    {
        this.GetComponent<HealthCount>().GetDamage(Hit);
        StartCoroutine(Invinsible(2));
    }

    public void GetDamagedOff()
    {
        Animator.SetBool("GetDamaged", false);
        Damageble = false;
        float StateSpeed = EnemyNavMeshAgent.speed;
        SetSpeed(0);
        StartCoroutine(Stay(1.3f, StateSpeed));
    }
    IEnumerator Stay(float time, float speed)
    {
        yield return new WaitForSeconds(time);
        if (CurrentState == TargetingState)
        {
            SetSpeed(speed);
        }
        else
        {
            SetSpeed(0);
        }
        yield break;
    }

    IEnumerator Invinsible(float time)
    {
        yield return new WaitForSeconds(time);
        Damageble = true;
        yield break;
    }
}
