using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTriggersControllers : MonoBehaviour
{
    public event Action<bool, GameObject> EventOnTriggerEnter;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            EventOnTriggerEnter?.Invoke(true, gameObject);
            //transform.parent.GetComponent<CapsileController>().PlayerFound();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            EventOnTriggerEnter?.Invoke(false, gameObject);
            //transform.parent.GetComponent<CapsileController>().PlayerLost();
        }
    }

    private void OnTriggerStay(Collider collider)
    {

    }
}
