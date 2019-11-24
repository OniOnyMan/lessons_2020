using UnityEngine;
using System.Collections;

public class PlayerRigidbodyPhisicController : HeroController
{
    public float JumpForce = 5;
    public LayerMask whatIsGround;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
        var footPoint = new Vector2(transform.position.x, transform.position.y);
        var grounded = Physics2D.OverlapCircle(footPoint, 1, whatIsGround);
        if (!(grounded == null))
            _rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Force);
    }


}
