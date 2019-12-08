using UnityEngine;
using System.Collections;

public class PlayerRigidbodyController : HeroController
{
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public override void Move()
    {
        var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        _rigidbody2D.velocity = direction * Speed * Time.deltaTime;
    }
}
