using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCatalyst : MonoBehaviour
{
    public UnityEvent catalyst;
    public void InitiateAction()
    {
        //do any events hooked up to this object through Unity Editor
        //add a float parameter to delay before invoking
        catalyst.Invoke();
    }


}
