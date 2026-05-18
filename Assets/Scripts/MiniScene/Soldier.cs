using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : MonoBehaviour
{
    internal int shoot;
    public bool LastFire;
    public bool walk;
    public bool RunPart;
    [SerializeField] Transform Demon;
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] Transform CheckPoint;
    [SerializeField] Transform SecondCheckPoint;
    [SerializeField] Animator DemonAnimator;

    private void Start()
    {
        RunPart = false;
        walk = false;
        shoot = 0;
    }
    public void FirePlus()
    {
        if (walk == true)
        {
            StartCoroutine(SetSpeed(0.15f));
            this.GetComponent<Animator>().SetBool("Walk", true);
            agent.destination = SecondCheckPoint.position;
            DemonAnimator.SetBool("Death", true);
        }
        if (shoot >= 3 && walk==false)
        {
            this.GetComponent<Animator>().SetBool("Run", true);
            RunPart = true;
            agent.speed = 1;
            DemonAnimator.SetBool("Rage", true);

        }
        shoot += 1;
    }

    private void Update()
    {
        if (RunPart == true)
        {
            agent.destination = CheckPoint.position;
        }
        if (LastFire == true)
        {
            Vector3 DirectionToTarget = (Demon.position - transform.position).normalized;
            Quaternion Rotate = Quaternion.LookRotation(DirectionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, Rotate, Time.deltaTime * 4.0F);
        }
    }

    IEnumerator SetSpeed(float time)
    {
        yield return new WaitForSeconds(time);
        agent.speed = 0.65f;
        yield break;
    }
}
