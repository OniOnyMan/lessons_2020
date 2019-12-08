using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRigidbodyPhisicController : HeroController
{
    public float MaxSpeed = 40;

    public float JumpForce = 5;
    public float OverlapRadius = 0.3f;
    public LayerMask WhatIsGround;

    private Rigidbody2D _rigidbody2D;
    private Renderer _renderer;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        Move();
        if (Input.GetAxis("Vertical") > 0)
        {
            Jump();
        }
    }

    public override void Move()
    {
        var directionX = _rigidbody2D.velocity.x + Input.GetAxis("Horizontal") * Speed * Time.deltaTime;

        if (Mathf.Pow(directionX, 2) > Mathf.Pow(MaxSpeed, 2))
        {
            directionX = directionX > 0 ? MaxSpeed : -MaxSpeed;
        }

        //PlayerPrefs.SetInt("Nameing_HideUI", (int)KeyCode.U);

        //Input.GetKey((KeyCode)PlayerPrefs.GetInt("Nameing_HideUI"));

        var velocity = new Vector2(directionX, _rigidbody2D.velocity.y);
        Debug.Log(velocity);
        _rigidbody2D.velocity = velocity;
    }

    public void Jump()
    {
        var bounds = _renderer.bounds;
        var footPoint = new Vector2(bounds.center.x, bounds.min.y);
        //Debug.Log("Foot point " + footPoint);

        var grounded = Physics2D.OverlapCircle(footPoint, OverlapRadius, WhatIsGround);

        if (!(grounded == null))
            _rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Force);
    }


}
