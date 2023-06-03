using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HandlerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ForwardValue(float normalizedvalue)
    {
        _animator.SetFloat("forward", normalizedvalue * 6);
    }

    public void RotateValue(float normalizedvalue)
    {
        _animator.SetFloat("rotate" , normalizedvalue * 3);
    }

    public void TriggerJump()
    {
        _animator.SetTrigger("Jump");
    }
}
