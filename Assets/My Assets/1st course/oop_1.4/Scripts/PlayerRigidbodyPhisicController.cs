using UnityEngine;
using System.Collections;

public class PlayerRigidbodyPhisicController : HeroController
{
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
        var directionX = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        var direction = new Vector2(_rigidbody2D.velocity.x + directionX, _rigidbody2D.velocity.y);

        _rigidbody2D.velocity = direction;
    }

    public void Jump()
    {
        var bounds = _renderer.bounds;
        var footPoint = new Vector2(bounds.center.x, bounds.min.y);
        Debug.Log("Foot point " + footPoint);

        var grounded = Physics2D.OverlapCircle(footPoint, OverlapRadius, WhatIsGround);

        if (!(grounded == null))
            _rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Force);
    }


}
