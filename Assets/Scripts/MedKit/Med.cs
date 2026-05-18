using UnityEngine;

public class Med : MonoBehaviour
{
    [SerializeField] AudioSource Heal;
    public bool used;
    private void Start()
    {
        used = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && used==false)
        {
            used=true;
            Heal.Play();
            if (other.transform.root.GetComponent<HealthCount>().health+25>100)
            {
                other.transform.root.GetComponent<HealthCount>().GetHeal(100-other.transform.root.GetComponent<HealthCount>().health);
            }
            else
            {
                other.transform.root.GetComponent<HealthCount>().GetHeal(25);
            }
        }
    }
}
