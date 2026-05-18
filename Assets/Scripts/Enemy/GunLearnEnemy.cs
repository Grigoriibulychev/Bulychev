using UnityEngine;
using UnityEngine.AI;

public class GunLearnEnemy : MonoBehaviour
{
    [SerializeField] FirstLevelDoor Door;
    [SerializeField] Transform destin;
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] Animator animator;
    public bool death = false;

    private void Start()
    {
        agent.speed= 3.0f;
    }
    public void SetTarget(Transform Aim)
    {
        destin = Aim;
        if (death == false)
        {
            animator.SetBool("Run", true);
        }
    }

    private void Update()
    {
        agent.destination=destin.position;
        if (this.GetComponent<HealthCount>().health <= 0 && death==false)
        {
            Death();
        }
    }

    public void Death()
    {
        agent.speed = 0;
        death = true;
        animator.SetBool("Death", true);
        Door.condition += 1;
    }
    public void Stop()
    {
        animator.SetBool("Death", false);
    }
}
