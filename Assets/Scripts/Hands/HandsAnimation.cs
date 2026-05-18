using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

public class HandsAnimation : MonoBehaviour
{
    [SerializeField]
    internal XRInputValueReader<float> m_TriggerInput;

    [SerializeField]
    internal XRInputValueReader<float> m_GripInput;

    //[SerializeField]
    //internal InputActionReference m_ButtonReader;

    [SerializeField]
    Animator m_animator;

    [SerializeField]
    public float lever;
    public bool Grab;

    private void Update()
    {
        m_animator.SetFloat("Trigger", m_TriggerInput.ReadValue());
        if (m_GripInput.ReadValue() > 1-lever && Grab)
        {
            float anim = lever - 0.28F;
            //m_animator.SetFloat("Grip", m_GripInput.ReadValue());
            m_animator.SetFloat("Grip", anim);
        }
        else
        {
            m_animator.SetFloat("Grip", m_GripInput.ReadValue());
        }

    }
}
