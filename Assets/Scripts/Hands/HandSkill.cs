using Unity.VisualScripting;
using UnityEngine;

public class HandSkill : Ability
{
    [SerializeField] Transform RightRotate;
    [SerializeField] int Damage;
    public bool skill = false;
    public GameObject visual;
    public override void Skill()
    {
        if (Hand.Grab == false)
        {
            if (Hand.m_TriggerInput.ReadValue() > 0)
            {
                if (skill == false)
                {
                    visual = Instantiate(VFX, this.transform.position, RightRotate.rotation, this.transform);
                    skill = true;
                    visual.GetComponent<ParticleSystem>().Play();
                    visual.AddComponent<BoxCollider>();
                    visual.GetComponent<BoxCollider>().isTrigger = true;
                    visual.GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 3);
                    visual.GetComponent<BoxCollider>().center = new Vector3(0, 0, 1.75f);
                    visual.AddComponent<FireTrigger>();
                    visual.AddComponent<FireTrigger>().damage = Damage;
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
