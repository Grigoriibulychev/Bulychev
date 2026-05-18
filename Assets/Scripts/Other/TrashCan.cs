using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Trash")
        {
            other.gameObject.SetActive(false);
        }
    }
}
