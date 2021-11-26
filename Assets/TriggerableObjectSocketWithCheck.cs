using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerableObjectSocketWithCheck : MonoBehaviour
{
    //triggerable objects need ONE collider set 'as trigger', and a kinematic rigidbody component attached.

    //the place where the object will sit
    [SerializeField]
    Transform objectSlotAnchor;
    
    [SerializeField]
    public string targetTag = "Untagged";

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

    }

    //game object tag checker
    public bool CheckTagsForMatch(GameObject other)
    {
        return other.CompareTag(targetTag);
    }





}
