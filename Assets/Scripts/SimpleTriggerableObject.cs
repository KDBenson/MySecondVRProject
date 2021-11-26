using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerableObject : MonoBehaviour
{
    //colliding/triggering object must have TriggerCatalyst component on it
    //triggerable objects must set 'as trigger', with kinematic rigidbody component.
    //todo add cooldown

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("This object is triggereing STO " + other.name);
        TriggerCatalyst catalyst = other.transform.GetComponent<TriggerCatalyst>();

        if(catalyst!= null)
        {            
            catalyst.InitiateAction();            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        TriggerCatalyst exitCatalyst = other.transform.GetComponent<TriggerCatalyst>();
        if(exitCatalyst!=null)
        {
            exitCatalyst.RevokeAction();
        }
    }

}
