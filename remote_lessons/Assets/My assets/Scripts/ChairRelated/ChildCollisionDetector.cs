using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollisionDetector : MonoBehaviour
{
    public event Action<Collision> OnCollisionEnterEvent;

    void Start()
    {
        OnCollisionEnterEvent += transform.parent.GetComponent<DestroyableChair>().OnCollisionEnter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionEnterEvent?.Invoke(collision);
    }
}
