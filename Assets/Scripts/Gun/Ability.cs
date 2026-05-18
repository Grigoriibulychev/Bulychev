using UnityEngine;
using UnityEngine.XR;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] public GameObject VFX;
    [SerializeField] public HandsAnimation Hand;
    public abstract void Skill();
}
