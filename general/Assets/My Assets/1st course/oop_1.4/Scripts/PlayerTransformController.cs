using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformController : HeroController
{
    public override void Move()
    {
        Vector2 direction = new Vector2();

        if (Input.GetKey(KeyCode.W))
        {
            direction += new Vector2(0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += new Vector2(0, -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += new Vector2(1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += new Vector2(-1, 0);
        }

        transform.Translate(direction * Speed);
    }
}
