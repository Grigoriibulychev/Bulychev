using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;

public class CheckpointInMiniScene : MonoBehaviour
{
    [SerializeField] GameObject Soldier;
    [SerializeField] Animator Demon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Soldier)
        {
            Soldier.GetComponent<Soldier>().RunPart = false;
            Soldier.GetComponent<Animator>().SetBool("Run", false);
            Soldier.GetComponent<Soldier>().LastFire = true;
            Soldier.GetComponent<Soldier>().walk = true;
            Soldier.GetComponent<Soldier>().walk = true;
            StartCoroutine(StartLastFire(0.5f));
        }
    }

    IEnumerator StartLastFire(float time)
    {
        yield return new WaitForSeconds(time);
        Soldier.GetComponent<Animator>().SetBool("Fire", true);
        Demon.SetBool("GetHit", true);
        yield break;
    }
}
