using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GunGrab : XRGrabInteractable
{
    [SerializeField] Transform LeftAttach;
    [SerializeField] Transform RightAttach;
    [SerializeField] HandsAnimation LeftAnimat;

    [SerializeField] HandsAnimation RightAnimat;

    internal HandsAnimation Animat;

    public float lever;

    private void OnCollisionEnter(Collision collision)
    {
        movementType = MovementType.VelocityTracking;
    }

    private void OnCollisionExit(Collision collision)
    {
        movementType = MovementType.Instantaneous;
    }
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        if (TryGetComponent(out SoundPad sounds))
        {
            sounds.PlaySound(sounds.Get);
        }
        if (args.interactorObject.transform.tag == "LeftHand")
        {
            if (TryGetComponent(out GunFire Fire))
            {
                Fire.use=true;
                Fire.Hand = LeftAnimat;
                Fire.armor += args.interactorObject.transform.root.GetComponent<PlayerParameters>().GunArmor;
                args.interactorObject.transform.root.GetComponent<PlayerParameters>().GunArmor = 0;
            }
            if (TryGetComponent(out Fire Device))
            {
                Device.Hand = LeftAnimat;
            }
            Animat=LeftAnimat;
            attachTransform = LeftAttach;
        }
        if (args.interactorObject.transform.tag == "RightHand")
        {
            if (TryGetComponent(out GunFire Fire))
            {
                Fire.use = true;
                Fire.Hand = RightAnimat;
                Fire.armor += args.interactorObject.transform.root.GetComponent<PlayerParameters>().GunArmor;
                args.interactorObject.transform.root.GetComponent<PlayerParameters>().GunArmor = 0;
            }
            if (TryGetComponent(out Fire Device))
            {
                Device.Hand = RightAnimat;
            }
            Animat = RightAnimat;
            attachTransform = RightAttach;
        }
        Animat.Grab = true;
        Animat.lever = lever;
        base.OnSelectEntering(args);
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if (TryGetComponent(out SoundPad sounds))
        {
            sounds.PlaySound(sounds.Out);
        }
        if(TryGetComponent(out GunFire Gun))
        {
            Gun.Hand = null;
            Gun.use = false;
        }
        Animat.Grab = false;
        Animat.lever = 0;
        base.OnSelectExited(args);
        args.interactableObject.transform.SetParent(null);
        args.interactableObject.transform.GetComponent<Rigidbody>().useGravity = true;
    }
}
