using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Batery : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "BateryCapsule")
        {
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
