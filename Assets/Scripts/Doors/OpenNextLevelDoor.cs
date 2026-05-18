using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class OpenNextLevelDoor : MonoBehaviour
{
    [SerializeField] Animator MainDoor;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Batery")
        {
            other.transform.position = new Vector3(1.3F, 1.896284F, -1938.039F);
            other.transform.rotation = Quaternion.Euler(0,0,90);
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            MainDoor.SetBool("Open", true);
            MainDoor.SetBool("Close", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Batery")
        {
            other.GetComponent<Rigidbody>().useGravity = true;
            other.GetComponent<Rigidbody>().isKinematic = false;
            MainDoor.SetBool("Close", true);
            MainDoor.SetBool("Open", false);
        }
        
    }
}
