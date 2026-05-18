using UnityEngine;

public class GoNextPosition : MonoBehaviour
{
    [SerializeField] Transform NextPos;
    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<GunLearnEnemy>().SetTarget(NextPos);
    }
}
