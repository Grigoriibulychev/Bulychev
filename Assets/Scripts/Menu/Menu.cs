using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Video;
using System.Linq;

public class Menu : MonoBehaviour
{
    public GameObject[] Walls;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem[] particleSystems;

    [SerializeField] Button Start;
    [SerializeField] Button Exit;
    void Awake()
    {
        Start.onClick.AddListener(StartLevel);
        Exit.onClick.AddListener(EndGame);
        for (int i = 0; i < 6; i++)
        {
            Walls[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }
    public void StartLevel()
    {
        Debug.Log("Start");
        particleSystems[0].Play();
        for (int i = 0; i < 6; i++)
        {
            Walls[i].GetComponent<MeshRenderer>().enabled = true;
        }
        animator.SetBool("Start", true);
        StartCoroutine(Load(6.5F));
    }

    IEnumerator Load(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadSceneAsync("SampleScene");
        yield break;
    }

    public void EndGame()
    {
        particleSystems[1].Play();
        Debug.Log("Quit");
        Application.Quit();
    }
}
