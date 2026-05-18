using System.Collections;
using UnityEngine;

public class AchivementStart : MonoBehaviour
{
    [SerializeField] GameObject[] Soldier;
    [SerializeField] Animator Demon;
    public bool start=true;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player" && start==true)
        {
            for (int i = 0; i < Soldier.Length; i++)
            {
                Soldier[i].GetComponent<Animator>().SetBool("Start", true);
            }
            StartCoroutine(DemonStart(0.55f));
            start = false;
        }
    }

    IEnumerator DemonStart(float time)
    {
        yield return new WaitForSeconds(time);
        Demon.SetBool("Start", true);
        yield break;
    }
}
