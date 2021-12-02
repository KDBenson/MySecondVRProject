using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleObjectSocket : MonoBehaviour
{
    //reattempting to do this socket

    //set this to the object with the transform position and rotation you want the object to appear at
    [SerializeField]    
    Transform objectSlotAnchor;

    private XRGrabInteractable _interactable = null;


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

    private void OnTriggerEnter(Collider other)
    {
        //release whatever was in there
        if(_interactable!= null)
        {
            Rigidbody _thisRB = _interactable.GetComponent<Rigidbody>();
            _thisRB.constraints = RigidbodyConstraints.None;
        }
        //move the thing that came in to the slot position
        GameObject collisionObject = other.gameObject;
        if (collisionObject != null)
        {
            collisionObject.transform.position = objectSlotAnchor.position;
            collisionObject.transform.rotation = objectSlotAnchor.rotation;
        }
        //set the new _interactable as this one
        _interactable = collisionObject.gameObject.GetComponent<XRGrabInteractable>();
        //freeze it if it is an XR Grab-Able by getting the rigidbody on it
        if (_interactable != null)
        {
            Rigidbody _thisRB = _interactable.GetComponent<Rigidbody>();
            _thisRB.constraints = RigidbodyConstraints.FreezeAll;
        }
        
    }

    public void FreezeInteractableBody()
    {
        //capture the rigidbody
        Rigidbody _thisRB = _interactable.GetComponent<Rigidbody>();
        _thisRB.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void ThawInteractableBody()
    {
        Rigidbody _thisRB = _interactable.GetComponent<Rigidbody>();
        _thisRB.constraints = RigidbodyConstraints.None;
    }


}
