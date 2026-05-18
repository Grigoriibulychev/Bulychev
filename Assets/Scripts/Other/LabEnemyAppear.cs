using UnityEngine;

public class LabEnemyAppear : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Enemy.SetActive(true);
        }
    }
}
