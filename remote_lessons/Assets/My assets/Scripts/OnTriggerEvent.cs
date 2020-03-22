using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEvent : MonoBehaviour
{
    public event Action<bool, GameObject> OnTriggered;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTriggered?.Invoke(true, other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggered?.Invoke(false, other.gameObject);
    }
}
