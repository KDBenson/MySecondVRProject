using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerableObject : MonoBehaviour
{
    //see if object going in is catalyst
    private void OnTriggerEnter(Collider other)
    {
        TriggerCatalyst catalyst = other.transform.GetComponent<TriggerCatalyst>();
        if(catalyst!= null)
        {
            catalyst.InitiateAction();
        }
    }
}
