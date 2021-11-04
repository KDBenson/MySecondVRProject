using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardReaderTrigger : XRBaseInteractor
{
    private XRBaseInteractable currentInteractable = null;

    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Object enters OnTriggerEnter is tagged: " + other.gameObject.tag);
        SetInteractable(other); //calls the SetInteractable for the object that's collided with the trigger
        //first it sets the interactable then comes back here
        //get the tag string comparison with other.gameObject.tag == "YourTag"
        if (other.gameObject.tag == "IDCard")
        {
            Debug.Log("IDCard put into OnTriggerEnter");
            GameManager.Instance.PlayerWins();
        }
    }


    private void SetInteractable(Collider other)
    {
        if (TryGetInteractable(other, out XRBaseInteractable interactable))
        {
            if (currentInteractable == null)
                currentInteractable = interactable;
            Debug.Log("setInteractable currentInteractable is tagged: " + currentInteractable.tag);
        }
        Debug.Log("leaving set interactable");
        Debug.Log(interactable.gameObject.tag);
    }

    private void OnTriggerExit(Collider other)
    {
       // Debug.Log("Object leaves OnTriggerEnter : " + other.gameObject.tag);
       // Debug.Log("On Trigger Exit, calling ClearInteractable(other)");
        ClearInteractable(other);
    }
    private void ClearInteractable(Collider other)
    {
       // Debug.Log("ClearInteractable: " + other.gameObject.tag);
        if (TryGetInteractable(other, out XRBaseInteractable interactable))
        {
            if (currentInteractable == interactable)
                currentInteractable = null;
        }
    }

    //Tries to get the XRBaseInteractable object attached to Collider object sent in
    private bool TryGetInteractable(Collider collider, out XRBaseInteractable interactable)
    {
        //Debug.Log("TryGetInteractable: " + collider.gameObject.tag);
        interactable = interactionManager.GetInteractableForCollider(collider);
        return false;
    }

    //I should have commented, I'm not sure why I need it the error is something about inheiritance
    public override void GetValidTargets(List<XRBaseInteractable> validTargets)
    {
        validTargets.Clear();
        validTargets.Add(currentInteractable);
    }

    //public override bool CanHover(XRBaseInteractable interactable)
    //{
    //    return base.CanHover(interactable) && currentInteractable == interactable && !interactable.isSelected;
    //}

    //public override bool CanSelect(XRBaseInteractable interactable)
    //{
    //    return false;
    //}


}
