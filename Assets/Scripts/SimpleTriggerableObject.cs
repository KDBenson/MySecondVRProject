using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerableObject : MonoBehaviour
{
    //colliding/triggering object must have TriggerCatalyst component on it
    //triggerable objects must set 'as trigger', with kinematic rigidbody component.

    private void OnTriggerEnter(Collider other)
    {
        TriggerCatalyst catalyst = other.transform.GetComponent<TriggerCatalyst>();

        if(catalyst!= null)
        {            
            catalyst.InitiateAction();            
        }

    }
}
