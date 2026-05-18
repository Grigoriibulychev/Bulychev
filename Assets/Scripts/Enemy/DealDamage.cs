using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] AudioSource Attack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<HealthCount>().GetDamage(20);
            Attack.Play();
        }
    }
}
