using UnityEngine;

public class AbilityLearnEnemy : MonoBehaviour
{
    [SerializeField] FirstLevelDoor Door;
    [SerializeField] Animator animator;
    public bool deathstop = true;

    private void Update()
    {
        if (this.GetComponent<HealthCount>().health <= 0 && deathstop)
        {
            animator.SetBool("Death", true);
            deathstop = false;
            Door.condition += 1;
        }
    }
}
