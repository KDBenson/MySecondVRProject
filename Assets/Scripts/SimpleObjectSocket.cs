using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleObjectSocket : MonoBehaviour
{
    //set this to the object with the transform position and rotation you want the object to snap into
    [SerializeField]    
    Transform objectSlotAnchor;

    private void Awake()
    {
        if (objectSlotAnchor == null)
        {
            objectSlotAnchor = transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject slottedObject = other.gameObject;

        if (slottedObject != null)
        {
            //puts the object into position and rotation
            slottedObject.transform.position = objectSlotAnchor.position;
            slottedObject.transform.rotation = objectSlotAnchor.rotation;
            //freeze the object in place, once this happens it is no longer moveable
            ////I cannot figure a way to 'stick' the card object into position and not have it pop out
            Rigidbody thisBody = slottedObject.GetComponent<Rigidbody>();
            thisBody.constraints = RigidbodyConstraints.FreezeAll;

        }
    }

}
