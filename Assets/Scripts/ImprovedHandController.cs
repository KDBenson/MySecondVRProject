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
        controllerActionGrip.action.performed += GripPress;
        controllerActionTrigger.action.performed += TriggerPress;

        //in case the animation freezes set returning hand anim and trigger to same
        controllerActionGrip.action.canceled += GripCancel;

        _handAnimator = GetComponent<Animator>();
    }

    private void GripCancel(InputAction.CallbackContext obj) => _handAnimator.SetFloat("Grip", 0);

    private void TriggerPress(InputAction.CallbackContext obj)
    {
        //"Trigger" is linked to the _handAnimator, tells it what blendtree
        _handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    }

    //method can be done this way as well
    private void GripPress(InputAction.CallbackContext obj) => _handAnimator.SetFloat("Grip", obj.ReadValue<float>());

}
