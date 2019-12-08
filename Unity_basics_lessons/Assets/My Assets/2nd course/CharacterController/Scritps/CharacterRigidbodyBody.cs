using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRigidbodyBody : MonoBehaviour
{
    public float MaxSpeed = 50;
    public float MoveSpeed = 10;
    public float RotateSpeed = 10;

    private Rigidbody _rigidbody;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");

        Move(verticalAxis);
        Rotate(horizontalAxis);
    }

    private void Rotate(float horizontalAxis)
    {
        var rotation = transform.rotation;
        _rigidbody.MoveRotation(rotation * Quaternion.Euler(0, horizontalAxis * Time.deltaTime * RotateSpeed * 10, 0));
    }

    private void Move(float verticalAxis)
    {
        var position = transform.position;
        var newVelocity = transform.forward * verticalAxis * MoveSpeed;
        var oldVelocity = _rigidbody.velocity;
        _rigidbody.velocity = new Vector3(newVelocity.x, oldVelocity.y, newVelocity.z);
        //Debug.Log(newVelocity);
        //if( newVelocity.magnitude <= MaxSpeed)
        //_rigidbody.velocity += newVelocity;
    }
}
