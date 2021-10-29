using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardReaderTrigger : XRBaseInteractor
{
    private XRBaseInteractable currentInteractable = null;

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void SetInteractable()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        
    }
    private void ClearInteractable()
    {

    }

    //todo- tutorial was out of date
    private bool TryGetInteractable(Collider collider, out XRBaseInteractable interactable)
    {
        interactable = interactionManager.GetInteractableForCollider(collider);
        return false;
    }

    public override void GetValidTargets(List<XRBaseInteractable> targets)
    {
        throw new System.NotImplementedException();
    }

}
