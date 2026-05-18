using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabNew : XRGrabInteractable
{
    public AudioSource GetWeapon;
    public AudioSource PutAwayWeapon;

    [SerializeField]
    Transform LeftAttachTransform;

    [SerializeField]
    Transform RightAttachTransform;

    [SerializeField]
    HandsAnimation LeftAnimat;

    [SerializeField]
    HandsAnimation RightAnimat;

    [SerializeField]
    CapsuleCollider WeaponLever;

    HandsAnimation Animat;
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        float square = WeaponLever.radius;
        if (args.interactorObject.transform.tag == "LeftHand")
        {
            Animat=LeftAnimat;
            attachTransform = LeftAttachTransform;
            Animat.Grab = true;
            Animat.lever = 1 - square;
        }
        if (args.interactorObject.transform.tag == "RightHand")
        {
            Animat=RightAnimat;
            attachTransform = RightAttachTransform;
            Animat.Grab = true;
            Animat.lever = 1 - square;
        }
        this.GetComponent<Rigidbody>().centerOfMass = new Vector3(0,0.15F,0);
        base.OnSelectEntering(args);
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
        GetWeapon.Play();
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.tag == "LeftHand")
        {
            Animat = LeftAnimat;
        }
        if (args.interactorObject.transform.tag == "RightHand")
        {
            Animat = RightAnimat;
        }
        Animat.Grab = false;
        Animat.lever = 0;
        base.OnSelectExited(args);
        args.interactableObject.transform.SetParent(null);
        PutAwayWeapon.Play();
    }
}
