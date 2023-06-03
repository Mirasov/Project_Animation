using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _acceleration; // Uskorenie
    [SerializeField] private float _MaxSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private HandlerAnimation _animationHandle;
        
    
    private Rigidbody _rigidbody;
    private Vector3 _velocity;
    
    private float _vertical;
    private float _horizontal;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        
        // Speed;
        _velocity = transform.forward * vertical * _acceleration;

        // value meaning in horizontal
     
        float rotateTurn = horizontal *  _rotateSpeed * Time.deltaTime; 
        transform.Rotate(Vector3.up, rotateTurn);

        UpdateAnimationValues(vertical, horizontal);
        checkJump();
    }

    private void checkJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animationHandle.TriggerJump();
        }
    }
        
    private void UpdateAnimationValues(float vertical, float horizontal)
    {
        _animationHandle.ForwardValue(vertical);
        _animationHandle.RotateValue(horizontal);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_velocity, ForceMode.Force);
        Vector3 xzVelocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
        if (xzVelocity.magnitude > _MaxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _MaxSpeed;
            _rigidbody.velocity = xzVelocity;
        } 
        
    }
}

