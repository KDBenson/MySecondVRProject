using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ImprovedHandController : MonoBehaviour
{
    //private but visible
    [SerializeField] InputActionReference controllerActionGrip;
    [SerializeField] InputActionReference controllerActionTrigger;

    //link to animator
    private Animator _handAnimator;

    //values only allocate when button pressed, more efficient than checking for input every frame
    private void Awake()
    {
        _handAnimator = GetHandAnimator();
        controllerActionGrip.action.performed += GripPress;
        controllerActionTrigger.action.performed += TriggerPress;

        //in case the animation freezes set returning hand anim and trigger to same
        controllerActionGrip.action.canceled += GripCancel;

    }

    private Animator GetHandAnimator()
    {
        //for some reason it will stop animating properly unless you do it this way
        //having _handAnimator = GetComponent<Animator>(); up in Awake is useless if more than 1 scene uses hands
        Animator _thisAnimator = GetComponent<Animator>();
        //do a null check and add a debug log
        return _thisAnimator;
    }

    private void GripCancel(InputAction.CallbackContext obj)
    {
        if (_handAnimator != null)
        {
            _handAnimator.SetFloat("Grip", 0);
        }        
        //when we change scenes what was there is destroyed, so it's going to be crying about nulls without this
    }

    private void TriggerPress(InputAction.CallbackContext obj)
    {
        if (_handAnimator != null)
        {
            //"Trigger" is linked to the _handAnimator, tells it what blendtree
            _handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
        }
    }

    private void GripPress(InputAction.CallbackContext obj) {
        if (_handAnimator != null)
        {
            _handAnimator.SetFloat("Grip", obj.ReadValue<float>());
        }
    } 

}
