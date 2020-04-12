using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Damage = 5;
    public float ForceMultiplier = 81;
    public float DestroyDelay = 5;

    public void AddForce(Vector3 force)
    {
        GetComponent<Rigidbody>().AddForce(force * ForceMultiplier);
        Destroy(gameObject, DestroyDelay);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
