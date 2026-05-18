using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DeleteInvisibleWall : MonoBehaviour
{
    [SerializeField] GameObject Condition;
    [SerializeField] GameObject ParentWall;
    private void OnTriggerEnter(Collider other)
    {
        if (Condition.GetComponent<HealthCount>().health <= 0) 
        {
            ParentWall.GetComponentInParent<Animator>().SetBool("Deleting", true);
            StartCoroutine(Deleting(1.1F));
        }
    }
    IEnumerator Deleting(float time)
    {
        yield return new WaitForSeconds(time);
        ParentWall.SetActive(false);
        yield break;
    }
}
