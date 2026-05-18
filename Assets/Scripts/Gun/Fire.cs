using Unity.VisualScripting;
using UnityEngine;

public class Fire : Ability
{
    [SerializeField] int Damage;
    public bool skill = false;
    public GameObject visual;
    public override void Skill()
    {
        if( Hand.Grab == true)
        {
            if (Hand.m_TriggerInput.ReadValue() > 0)
            {
                if (skill == false)
                {
                    Quaternion Rotation = Quaternion.Euler(0f, 0f, 0f);
                    visual = Instantiate(VFX, this.transform.position, Rotation, this.transform);
                    skill = true;
                    visual.GetComponent<ParticleSystem>().Play();
                    visual.AddComponent<BoxCollider>();
                    visual.GetComponent<BoxCollider>().isTrigger = true;
                    visual.GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 3);
                    visual.GetComponent<BoxCollider>().center = new Vector3(0, 0, 1.75f);
                    visual.AddComponent<FireTrigger>();
                    visual.AddComponent<FireTrigger>().damage=Damage;
                }
            }
            else
            {
                if (skill == true)
                {
                    Destroy(visual);
                }
                skill = false;
            }
        }
        else
        {
            if (skill == true)
            {
                Destroy(visual);
            }
            skill = false;
        }

    }

    private void Update()
    {
        Skill();
    }
}
