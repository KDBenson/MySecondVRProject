using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleObjectSocketWithTagCheck : MonoBehaviour
{
    //case sensitive string for the object ID to compare for, only matching tags will slot
    public string targetTag = "Untagged";

    //set this to the object with the transform position and rotation you want the object to appear at
    [SerializeField]
    Transform objectSlotAnchor;
    //this logic can be extended to make an object socket with an 'eject' transform if just falling out is too ugly.


    //an interactable object has a rigidbody, we want to capture that specific rigidbody to freeze it
    private XRGrabInteractable curInteractable = null;
    private Rigidbody heldRigidBody = null;
    private bool socketOccupied = false;

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
        //if (curInteractable != null)
        //{
        //    FreeSocket();
        //}
        if (socketOccupied)
        {
            FreeSocket();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //capture the object attatched to the collider going into the trigger
        GameObject collidedObject = other.gameObject;
        //remove what is in the socket if occupied
        if(socketOccupied)
        {
            FreeSocket();
        }

        if (collidedObject != null && CheckTagsForMatch(collidedObject))
        {
            //puts the object into position and rotation immediately, and physics still happens
            collidedObject.transform.position = objectSlotAnchor.position;
            collidedObject.transform.rotation = objectSlotAnchor.rotation;
            //set the interactable into the socket
            if (heldRigidBody == null)
            {               
                SetCurrentInteractable(collidedObject);
                FreezeMotion();
                socketOccupied = true;
            }

        }
    }

    private bool FreeSocket()
    {
        ReleaseMotion();
        ClearCurrentInteractable();
        return socketOccupied = false;
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
        if(heldRigidBody!=null)
        {
            heldRigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void ReleaseMotion()
    {
        if(heldRigidBody!=null)
        {
            heldRigidBody.constraints = RigidbodyConstraints.None;
        }
    }

    public bool CheckTagsForMatch(GameObject other)
    {
        return other.CompareTag(targetTag);
    }

}
