using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardReaderTrigger : XRBaseInteractor
{
    private XRBaseInteractable currentInteractable = null;
    public string targetTag = string.Empty;

    //CardReaderTrigger is a modified XRBaseInteractor
    //implement inherited abstract member 'XRBaseInteractor.GetValidTargets(List<XRBaseInteractable>)
    public override void GetValidTargets(List<XRBaseInteractable> validTargets)
    {
        validTargets.Clear();
        validTargets.Add(currentInteractable);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Object enters OnTriggerEnter is tagged: " + other.gameObject.tag); <-ok
        SetInteractable(other); //calls the SetInteractable for the object that's collided with the trigger
        CompareInteractableTags();

    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("----------------------------On Trigger Exit, calling ClearInteractable(other)");
        ClearInteractable(other);
    }
    //Tries to get the XRBaseInteractable object attached to Collider object sent in
    private bool TryGetInteractable(Collider collider, out XRBaseInteractable interactable)
    {
        Debug.Log("hello from TryGetInteractable; the tag on Collider collider is ");
        Debug.Log(collider.tag);
        interactable = interactionManager.GetInteractableForCollider(collider);
        Debug.Log("and the tag on the interactable made is ");
        Debug.Log(interactable.tag);
        return false;
    }

    private void CompareInteractableTags()
    {
        Debug.Log("Hello from CompareInteractableTags");
        if (currentInteractable != null && CompareTargetTags())
        {
            Debug.Log("A match is made!");
        }
    }

    //return true if tags match
    private bool CompareTargetTags()
    {
        Debug.Log("hello from CompareTargetTags, target tag is : " + targetTag);
        return currentInteractable.CompareTag(targetTag);
    }

    private void SetInteractable(Collider other)
    {
        Debug.Log("hello from SetInteractable: tagIn " + other.gameObject.tag);
        if (TryGetInteractable(other, out XRBaseInteractable interactable))
        {
            if (currentInteractable == null)
                currentInteractable = interactable;
        }
        Debug.Log("currentinteractable assigned" + interactable.gameObject.tag);

    }

    private void ClearInteractable(Collider other)
    {
        if (TryGetInteractable(other, out XRBaseInteractable interactable))
        {            
            if (currentInteractable == interactable)
                currentInteractable = null;
        }
    }


}
