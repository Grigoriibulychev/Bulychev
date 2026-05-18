using UnityEngine;
using UnityEngine.AI;

public class EnemyGo : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] NavMeshAgent NavMeshAgent;
    private void Update()
    {
        NavMeshAgent.destination=Target.position;
    }
}
