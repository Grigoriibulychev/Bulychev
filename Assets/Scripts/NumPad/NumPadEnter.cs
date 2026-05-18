using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class NumPadEnter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Code;
    public string Password;
    [SerializeField] BossState Boss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Code.text == Password)
            {
                Boss.DeathCount += 1;
                Code.text = "";
                if(Boss.DeathCount >= 2)
                {
                    Boss.animator.SetBool("Death", true);
                    Boss.SetSpeed(0);
                }
            }
            else
            {
                Code.text = "";
            }
        }
    }
}
