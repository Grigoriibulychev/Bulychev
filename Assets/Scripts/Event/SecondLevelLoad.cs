using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondLevelLoad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            SceneManager.LoadSceneAsync("Level2");
        }
    }
}
