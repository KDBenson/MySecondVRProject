using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleObjectSocket : MonoBehaviour
{
    //set this to the object with the transform position and rotation you want the object to snap into
    [SerializeField]    
    Transform objectSlotAnchor;

    //an interactable object has a rigidbody, we want to capture that specific rigidbody to freeze it
    private XRGrabInteractable curInteractable = null;

    //if no transform was set in the editor, set the transform to the same as the object this component is on
    private void Awake()
    {
        if (objectSlotAnchor == null)
        {
            objectSlotAnchor = transform;
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
            //first get the grabinteractable- note that only 1 XR component like this is on an object and it must have a rigidbody
            if (curInteractable == null)
            {
                //set the currently manipulated object to this one coming in
                curInteractable = collidedObject.GetComponent<XRGrabInteractable>();
                // Debug.Log("breathe in breathe out, you've got this.");

                //nullcheck makes sure that there is the grabinteractable component on the object
                if (curInteractable != null)
                {
                    //then we want to get that objects rigidbody and change it to be frozen
                    Rigidbody theBody = curInteractable.GetComponent<Rigidbody>();
                    theBody.constraints = RigidbodyConstraints.FreezeAll;
                    //the object is now frozen at the slot anchor transforms position and rotation until it is removed.
                }                               

            }
        }
    }


}
