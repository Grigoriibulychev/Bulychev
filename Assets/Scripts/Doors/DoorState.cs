using UnityEngine;

public class DoorState : MonoBehaviour
{
    [SerializeField]
    Animator Gates;
    private void OnTriggerEnter(Collider other)
    {
        Gates.SetBool("Opening", true);
        Gates.SetBool("Closing", false);
    }

    private void OnTriggerExit(Collider other)
    {
        Gates.SetBool("Closing", true);
        Gates.SetBool("Opening", false);
    }
}
