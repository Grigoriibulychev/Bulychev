using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
public class GrabParenter : XRGrabInteractable
{
    public bool physics;
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        physics=true;
        StartCoroutine(Test(1));
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        if (physics) {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "BateryCapsule")
        {
            gameObject.GetComponent<GrabParenter>().movementType = MovementType.Instantaneous;
        }
    }

    IEnumerator Test(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<GrabParenter>().movementType = MovementType.VelocityTracking;
        yield break;
    }
}

