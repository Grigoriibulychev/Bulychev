using UnityEngine;

public class BossFightTrigger : MonoBehaviour
{
    [SerializeField] BossState Boss;
    [SerializeField] GameObject Wall;
    public bool InTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Boss.SwitchState(Boss.BossTargetState);
            Wall.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Boss.SwitchState(Boss.BossIdleState);
        }
        if (Boss.BossCurrentState == Boss.BossDeathState)
        {
            Wall.SetActive(false);
        }
    }
}
