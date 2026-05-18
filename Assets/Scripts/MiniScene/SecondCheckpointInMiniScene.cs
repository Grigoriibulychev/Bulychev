using UnityEngine;
using UnityEngine.AI;

public class SecondCheckpointInMiniScene : MonoBehaviour
{
    [SerializeField] GameObject Soldier;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Soldier)
        {
            Soldier.GetComponent<NavMeshAgent>().speed = 0;
            Soldier.GetComponent<Animator>().SetBool("Finish",true);
        }
    }
}
