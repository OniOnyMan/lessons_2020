using UnityEngine;
using System.Collections;

public class PlayerTransformAxiesController : HeroController
{
    public override void Move()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
