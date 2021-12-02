using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class TagCheckObjectSocketAndEject : MonoBehaviour
{
    //case sensitive string for the object ID to compare for, only matching tags will slot
    public string targetTag = "Untagged";

    //set this to the object with the transform position and rotation you want the object to appear at
    [SerializeField]
    Transform objectSlotAnchor;
    [SerializeField]
    Transform objectEjectAnchor;

    private XRGrabInteractable _interactable = null;


    //set the positions for the hold and eject slots
    private void Awake()
    {
        if (objectSlotAnchor == null)
        {
            objectSlotAnchor = transform;
        }
        if(objectEjectAnchor == null)
        {
            objectEjectAnchor = transform;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        //if there's already an object in the slot anchor
        if (_interactable != null)
        {
            //eject it to the ejection spot
            MoveGrabableToAnchor(_interactable, objectEjectAnchor);
            StartCoroutine(HangOnUntilMoved(_interactable, objectEjectAnchor));
            ThawGrabableBody(_interactable);
            //empty the placeholder
            _interactable = null;
        }

        GameObject collisionObject = other.gameObject;
        //  //call to check tags, skip if not a match
        if (CheckTagsForMatch(collisionObject))
        {
            StartCoroutine(PauseTriggerArea());
            //  //the interactable entering the trigger
            XRGrabInteractable incomingGrabAble = collisionObject.gameObject.GetComponent<XRGrabInteractable>();

            MoveGrabableToAnchor(incomingGrabAble, objectSlotAnchor);

            StartCoroutine(HangOnUntilMoved(incomingGrabAble, objectSlotAnchor));
            Debug.Log("HELLO TagCheckObjSocketEject- OnTriggerENTER- " + incomingGrabAble.name);
            _interactable = incomingGrabAble;
        }
    }


    //private IEnumerator OnTriggerExit(Collider other)
    //{
    //    ////wait one frame
    //    yield return null;
    //    ////_interactable = null;
    //    GameObject exitingObject = other.gameObject;
    //    XRGrabInteractable exitingGrabAble = null;

    //    if (CheckTagsForMatch(exitingObject))
    //    {
    //        exitingGrabAble = exitingObject.gameObject.GetComponent<XRGrabInteractable>();
    //        //  //the interactable leaving the trigger matches the tag // //guess that could be done via interaction layers
    //        EjectGrabableToAnchor(exitingGrabAble, objectEjectAnchor);

    //    }

    //    if (exitingGrabAble != null)
    //    {
    //        Debug.Log("GOODBYE TagCheckObjSocketEject- OnTriggerExit- exiting grabable not null " + exitingGrabAble.name);
    //    }

    //}

    //the challenge I'm facing is that when the grabbable object moves to the socket slot From OnTriggerEnter it fires OnTriggerExit
    private void OnTriggerExit(Collider other)
    {
        GameObject exitingObject = other.gameObject;
        if (CheckTagsForMatch(exitingObject))
        {
            Debug.Log("GOODBYE TagCheckObjSocketEject- OnTriggerExit- exiting object " + exitingObject.name);
        }
    }


    public void MoveGrabableToAnchor(XRGrabInteractable grabAble, Transform anchor)
    {
        //moves the whole XRGrabInteractable object into whatever anchor place 
        grabAble.transform.position = anchor.position;
        grabAble.transform.rotation = anchor.rotation;
    }

    public void FreezeGrabableBody(XRGrabInteractable grabAble)
    {
        //use physics to stay put by enabling kinematic
        Rigidbody _thisRB = grabAble.GetComponent<Rigidbody>();
        _thisRB.isKinematic = true;
    }

    public void ThawGrabableBody(XRGrabInteractable grabAble)
    {
        //stop using physics to stay put by diabling isKinematic
        Rigidbody _thisRB = grabAble.GetComponent<Rigidbody>();
        _thisRB.isKinematic = false;
    }

    public bool CheckTagsForMatch(GameObject other)
    {
        return other.CompareTag(targetTag);
    }

    public IEnumerator PauseTriggerArea()
    {
        ////wait one frame
        yield return null;
    }

    //WaitUntil stops until the function you provide no longer returns false:
    public IEnumerator HangOnUntilMoved(XRGrabInteractable grabAble, Transform anchor)
    {
        //don't do the thing, until this comes back as true; ie; don't keep going until this grabable is in position
        yield return new WaitUntil(() => grabAble.transform.position == anchor.position);
    }

    //WaitWhile stops until the function you provide returns false:
    public IEnumerator ResumeNormalMotionAfter(XRGrabInteractable grabAble, Transform anchor)
    {
        //don't do the thing if the grabable is in the slot it needs to be
        yield return new WaitWhile(() => grabAble.transform.position == anchor.position);
    }

}
