using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerableObjectSocketWithCheck : MonoBehaviour
{
    // // // // // penne

    //triggerable objects need ONE collider set 'as trigger', and a kinematic rigidbody component attached.
    //ALWAYS SET THE RIGIDBODY ON THE TRIGGER TO IS KINEMATIC = TRUE

    //the place where the object will sit
    [SerializeField]
    Transform objectSlotAnchor;
    
    [SerializeField]
    public string targetTag = "Untagged";

    //when a grab interactable object comes in, you need to get the attached rigidbody constraints to None or FreezeAll
    private XRGrabInteractable _interactable;


    //if no transform was set in the editor, set the transform to the same as the object this component is on
    private void Awake()
    {
        if (objectSlotAnchor == null)
        {
            objectSlotAnchor = transform;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //release any interactable already frozen
        if(_interactable!=null)
        {
            ThawInteractableBody();
        }

        //check if the object coming in matches the target tag
        GameObject collisionObject = other.gameObject;
        if (CheckTagsForMatch(collisionObject))
        {
            //great! now that it is the right kind of object, lets get a reference to the interactable
            _interactable = collisionObject.gameObject.GetComponent<XRGrabInteractable>();

            //drop the grab interactable?
            //can't do object.Drop(); because it's a protected virtual void method. look at the xr interaction manager?
            HoldObjectInSocket(collisionObject.gameObject.GetComponent<XRGrabInteractable>());

            //move it into the position
            _interactable.transform.position = objectSlotAnchor.position;
            _interactable.transform.rotation = objectSlotAnchor.rotation;

            _interactable.retainTransformParent = false;

            FreezeInteractableBody();


            Debug.Log("From within OnTriggerEnter has been set off by " + other.name);
            //now you can look for any catalyst components and trigger them
            TriggerCatalyst catalyst = other.transform.GetComponent<TriggerCatalyst>();

            if (catalyst != null)
            {
                catalyst.InitiateAction();
            }

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (_interactable != null)
        {
            //testing notes for later- experimenting with thisline
            _interactable.retainTransformParent = true;
            ThawInteractableBody();
        }
    }

    //game object tag checker
    public bool CheckTagsForMatch(GameObject other)
    {
        return other.CompareTag(targetTag);
    }

    public void MoveInteractableBodyToAnchor()
    {
        _interactable.transform.position = objectSlotAnchor.position;
        _interactable.transform.rotation = objectSlotAnchor.rotation;
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

    private IEnumerator HoldObjectInSocket(XRGrabInteractable grabbable)
    {
        _interactable = grabbable;
        MoveInteractableBodyToAnchor();
        yield return new WaitUntil(() => _interactable.transform.position == objectSlotAnchor.position);
        FreezeInteractableBody();
    }


}
