using System.Collections;
using UnityEngine;

public class WeaponDealDamage : MonoBehaviour
{
    public int damage;
    public bool HitTrigger=false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<HealthCount>().alive == true)
        {
            if (HitTrigger == false && collision.gameObject.GetComponentInParent<EnemyStateManager>().Damageble==true)
            {
                collision.gameObject.GetComponentInParent<Animator>().SetBool("GetDamaged", true);
                collision.gameObject.GetComponentInParent<EnemyStateManager>().Hit = damage;
            }
            HitTrigger = true;
            StartCoroutine(DoIt(1.5f));
        }
    }

    IEnumerator DoIt(float time)
    {
        yield return new WaitForSeconds(time);
        HitTrigger = false;
        yield break;
    }
}
