using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestAnimationTriggets : MonoBehaviour
{
    [SerializeField] Animator _anim;

    private void Awake()
    {
        if(_anim == null)
        {
            _anim = GetComponent<Animator>();
        }
    }

    public void DoAnimation(string animTriggrName)
    {
        _anim.SetTrigger(animTriggrName);
    }

    public void ResetAnimation(string animTriggrName)
    {
        _anim.ResetTrigger(animTriggrName);
    }

}
