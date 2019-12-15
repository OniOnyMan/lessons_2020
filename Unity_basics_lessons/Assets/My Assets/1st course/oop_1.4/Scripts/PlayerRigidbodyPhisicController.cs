using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(My_Animator.HeroController))]
public class PlayerRigidbodyPhisicController : HeroController
{
    public float MaxSpeed = 40;

    public float JumpForce = 5;
    public float OverlapRadius = 0.3f;
    public LayerMask WhatIsGround;
    public float RespawnLine = -20;

    private Rigidbody2D _rigidbody2D;
    private Renderer _renderer;
    private bool _grounded = false;
    private bool _prevGrounded = true;
    private My_Animator.HeroController _animator;
    private Vector3 _startPos;

    private void Start()
    {
        _animator = GetComponent<My_Animator.HeroController>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<Renderer>();
        _startPos = transform.position;
    }

    private void FixedUpdate()
    {
        _grounded = IsGrounded();
        Debug.Log(_grounded);
        if (_prevGrounded != _grounded)
        {
            _animator.IsFalling(_grounded);
            _prevGrounded = _grounded;
        }
        
        Move();

        if (Input.GetAxis("Vertical") > 0)
        {
            Jump();
        }

        if (transform.position.y < RespawnLine)
        {
            Respawn();
        }
    }

    public override void Move()
    {
        var directionX = _rigidbody2D.velocity.x + Input.GetAxis("Horizontal") * Speed * Time.deltaTime;

        if (Mathf.Pow(directionX, 2) > Mathf.Pow(MaxSpeed, 2))
        {
            directionX = directionX > 0 ? MaxSpeed : -MaxSpeed;
        }

        var velocity = new Vector2(directionX, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = velocity;
    }

    public void Jump()
    {
        if (_grounded)
        {
            _animator.Jump();
            _rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Force);
        }
    }

    private bool IsGrounded()
    {
        var bounds = _renderer.bounds;
        var footPoint = new Vector2(bounds.center.x, bounds.min.y);

        return Physics2D.OverlapCircle(footPoint, OverlapRadius, WhatIsGround);
    }

    private void Respawn()
    {
        transform.position = _startPos;
    }
}
