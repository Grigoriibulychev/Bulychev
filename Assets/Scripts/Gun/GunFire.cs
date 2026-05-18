using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class GunFire : MonoBehaviour
{
    public bool shotDone=false;
    public int damage;
    public int armor;
    public ParticleSystem flash;
    public GameObject hitflash;
    public bool use;
    [SerializeField] public HandsAnimation Hand;
    [Header("Ray")]
    [SerializeField] public int bullets;
    [SerializeField] public bool spread;
    [SerializeField] public float maxDistance;
    [SerializeField] public LayerMask layerMask;
    public void PerformAttack()
    {
        for (int i = 0; i < bullets; i++)
        {
            PerformRaycast();
        }
    }

    public void PerformRaycast()
    {
        var direction = spread ? transform.forward+CalculateSpread(): transform.forward;
        Ray ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
        {
            var hitCollider = hit.collider;
            if(hitCollider.transform.root.TryGetComponent(out HealthCount Enemy))
            {
                Enemy.GetDamage(damage);
                GameObject visual=Instantiate(hitflash, hit.collider.transform.position, hit.transform.rotation, hit.transform);
                visual.GetComponent<ParticleSystem>().Play();
                Destroy(visual, 1.5f);
            }
            else
            {
                if (hitCollider.TryGetComponent(out HealthCount enemy))
                {
                    enemy.GetDamage(damage);
                    GameObject visual = Instantiate(hitflash, hit.collider.transform.position, hit.transform.rotation, hit.transform);
                    visual.GetComponent<ParticleSystem>().Play();
                    Destroy(visual, 1.5f);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        var ray=new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
        {
            DrawRay(ray, hit.point, hit.distance, Color.white);
        }
        else
        {
            DrawRay(ray, hit.point, hit.distance, Color.red);
        }
    }

    private static void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
    {
        Debug.DrawRay(ray.origin, ray.direction*distance, color);
        Gizmos.color = color;
        const float radious = 0.15f;
        Gizmos.DrawSphere(hitPosition, radious);
    }
    public Vector3 CalculateSpread()
    {
        return new Vector3
        {
            x = Random.Range(0.1f, 1.0f),
            y = Random.Range(0.1f, 1.0f),
            z = Random.Range(0.1f, 1.0f)
        };
    }

    private void Update()
    {
        if (use)
        {
            if (Hand.m_TriggerInput.ReadValue() > 0)
            {
                if (armor >= bullets && shotDone == false && Hand.Grab == true && use == true)
                {
                    if (TryGetComponent(out SoundPad attack))
                    {
                        attack.PlaySound(attack.Attack);
                    }
                    flash.Play();
                    shotDone = true;
                    armor -= bullets;
                    PerformAttack();
                }
            }
            else
            {
                shotDone = false;
            }
        }
    }
}
