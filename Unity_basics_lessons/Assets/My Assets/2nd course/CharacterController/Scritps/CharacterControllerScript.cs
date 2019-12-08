using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float MoveSpeed = 10;

    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();   
    }

    private void Update()
    {
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");

        var gravity = -9.82f * Time.deltaTime;
        var direction = new Vector3(horizontalAxis * Time.deltaTime * MoveSpeed, gravity, verticalAxis * Time.deltaTime * MoveSpeed);
        //print(gravity);
        print(direction);
        _controller.Move(direction);
    }
}
