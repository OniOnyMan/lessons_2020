using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTransformController : MonoBehaviour
{
    public float MoveSpeed = 10;
    public float RotateSpeed = 10;

    void Start()
    {
        
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
        transform.Rotate(Vector3.up, horizontalAxis * Time.deltaTime * RotateSpeed * 10);
    }

    private void Move(float verticalAxis)
    {
        transform.Translate(Vector3.forward * verticalAxis * MoveSpeed * Time.deltaTime);
    }
}
