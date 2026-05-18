using System.Collections;
using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    public int damage;
    public bool ready = true;
    private void OnTriggerStay(Collider other)
    {
        if (ready)
        {
            if (other.transform.root.TryGetComponent(out HealthCount Enemy))
            {
                Enemy.GetDamage(damage);
                ready = false;
                StartCoroutine(FirePause(0.5f));
            }
        }
        
    }

    IEnumerator FirePause(float time)
    {
        yield return new WaitForSeconds(time);
        ready = true;
        yield break;
    }
}
