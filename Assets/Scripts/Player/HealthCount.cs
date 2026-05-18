using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCount : MonoBehaviour
{
    [SerializeField] string SceneName;
    public int health;
    public bool alive;
    void Start()
    {
        health = 100;
        alive = true;
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        Debug.Log("Health "+health);
        if(TryGetComponent(out PlayerHealthBar HPBar))
        {
            HPBar.ChangeHPBar();
        }
        if(health <= 0)
        {
            if(this.tag == "Player")
            {
                Debug.Log("End");
                SceneManager.LoadScene(SceneName);
            }
            if(this.tag == "Enemy")
            {
                if (alive == true)
                {
                    this.GetComponent<HealthCount>().enabled = false;
                    alive = false;
                    this.GetComponent<Animator>().SetBool("Death", true);
                }

            }
        }
    }

    public void GetHeal(int heal)
    {
        health += heal;
        if (TryGetComponent(out PlayerHealthBar HPBar))
        {
            HPBar.ChangeHPBar();
        }
    }
}
