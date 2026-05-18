using UnityEngine;

public class FirstLevelDoor : MonoBehaviour
{
    public int condition = 0;
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && condition>=4)
        {
            animator.SetBool("Opening", true);
            animator.SetBool("Closing", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && condition>=4)
        {
            animator.SetBool("Opening", false);
            animator.SetBool("Closing", true);
        }
    }
}
