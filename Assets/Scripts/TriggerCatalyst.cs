using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCatalyst : MonoBehaviour
{
    public UnityEvent catalyst;
    public void InitiateAction()
    {
        catalyst.Invoke();
    }
}
