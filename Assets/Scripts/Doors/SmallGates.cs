using UnityEngine;

public class SmallGates : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy" || other.tag == "Player")
        {        
            animator.SetBool("Open",true);
            animator.SetBool("Close", false);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Player")
        {
            animator.SetBool("Open", false);
            animator.SetBool("Close", true);

        }
    }
}
