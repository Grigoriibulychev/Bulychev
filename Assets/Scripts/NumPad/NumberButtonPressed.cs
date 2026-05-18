using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberButtonPressed : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Code;
    [SerializeField] string Value;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Code.text += Value;
        }
    }
}
