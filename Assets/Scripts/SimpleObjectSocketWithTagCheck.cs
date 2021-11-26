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
    //private XRGrabInteractable curInteractable = null;
    //private Rigidbody heldRigidBody = null;
    //private bool socketOccupied = false;

    private XRGrabInteractable _interactable;


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
        if (_interactable != null)
        {
            Rigidbody _thisRB = _interactable.GetComponent<Rigidbody>();
            _thisRB.constraints = RigidbodyConstraints.None;
        }
        GameObject collisionObject = other.gameObject;
        if (CheckTagsForMatch(collisionObject))
        {
            collisionObject.transform.position = objectSlotAnchor.position;
            collisionObject.transform.rotation = objectSlotAnchor.rotation;
            _interactable = collisionObject.gameObject.GetComponent<XRGrabInteractable>();
            if (_interactable != null)
            {
                Rigidbody _thisRB = _interactable.GetComponent<Rigidbody>();
                _thisRB.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }

    //re-enable moving the object that was held in the slot anchor
    private void OnTriggerExit(Collider other)
    {
        //if (_interactable != null)
        //{
        //    Rigidbody _thisRB = _interactable.GetComponent<Rigidbody>();
        //    _thisRB.constraints = RigidbodyConstraints.None;
        //}
        GameObject exitingObject = other.gameObject;
        //release the freeze
        XRGrabInteractable exitingGrabAble = exitingObject.gameObject.GetComponent<XRGrabInteractable>();
        if (exitingGrabAble != null)
        {
            Rigidbody _thisRB = exitingGrabAble.GetComponent<Rigidbody>();
            _thisRB.constraints = RigidbodyConstraints.None;
        }

    }


    public bool CheckTagsForMatch(GameObject other)
    {
        return other.CompareTag(targetTag);
    }

}
