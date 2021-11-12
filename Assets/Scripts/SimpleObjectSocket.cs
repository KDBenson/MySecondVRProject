using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleObjectSocket : MonoBehaviour
{
    //public SimpleTagCheck tagChecker;

    //set this to the object with the transform position and rotation you want the object to appear at
    [SerializeField]    
    Transform objectSlotAnchor;

    //an interactable object has a rigidbody, we want to capture that specific rigidbody to freeze it
    private XRGrabInteractable curInteractable = null;
    private Rigidbody heldRigidBody = null;

    //if no transform was set in the editor, set the transform to the same as the object this component is on
    private void Awake()
    {
        if (objectSlotAnchor == null)
        {
            objectSlotAnchor = transform;
        }
    }

    //re-enable moving the object that was held in the slot anchor
    private void OnTriggerExit(Collider other)
    {
        if (curInteractable != null)
        {
            ReleaseMotion();
            ClearCurrentInteractable();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //capture the object attatched to the collider going into the trigger
        GameObject collidedObject = other.gameObject;

        if (collidedObject != null)
        {
            //puts the object into position and rotation immediately, but physics still happens
            collidedObject.transform.position = objectSlotAnchor.position;
            collidedObject.transform.rotation = objectSlotAnchor.rotation;

            if (heldRigidBody == null)
            {
                SetCurrentInteractable(collidedObject);  
                FreezeMotion();   
            }
        }



    }

    private void SetCurrentInteractable(GameObject gameObject)
    {
        curInteractable = gameObject.GetComponent<XRGrabInteractable>();
        heldRigidBody = curInteractable.GetComponent<Rigidbody>();
    }

    private void ClearCurrentInteractable()
    {
        curInteractable = null;
        heldRigidBody = null;
    }

    private void FreezeMotion()
    {
        heldRigidBody.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void ReleaseMotion()
    {
        heldRigidBody.constraints = RigidbodyConstraints.None;
    }

}