using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroController : MonoBehaviour
{
    public float Speed = 10;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        Move();
	}

    public abstract void Move();
}
