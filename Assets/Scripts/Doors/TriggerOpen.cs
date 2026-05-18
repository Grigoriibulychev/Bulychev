using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TriggerOpen : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Animator BateryAnimator;
    [SerializeField] GameObject TrainingMonster;
    [SerializeField] GameObject Wall;
    [SerializeField] Image[] images; 
    private void OnTriggerEnter(Collider other)
    {
        if(this.GetComponent<CapsuleCollider>() == true)
        {
            if (other.tag == "Batery")
            {
                BateryAnimator.SetBool("StartAnimation", true);
                animator.SetBool("Open", true);
                animator.SetBool("Close", false);
                other.GetComponent<CapsuleCollider>().enabled = false;
                BateryAnimator.gameObject.transform.position = new Vector3(72.0660019F, 2.1F, 75.3249969F);
                other.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                this.GetComponent<Rigidbody>().useGravity = false;
                this.GetComponent<Rigidbody>().isKinematic = true;
                images[0].enabled = false;
                images[1].enabled = true;
            }
            return;
        }
        if(this.GetComponent <BoxCollider>() == true)
        {
            if (other.tag == "Player")
            {
                Wall.GetComponent<MeshRenderer>().enabled = true;
                Wall.GetComponent<Animator>().SetBool("Appear", true);
                TrainingMonster.GetComponent<EnemyStateManager>().Target = other.transform;
                animator.SetBool("Close", true);
                animator.SetBool("Open", false);
            }

        }
    }
}
