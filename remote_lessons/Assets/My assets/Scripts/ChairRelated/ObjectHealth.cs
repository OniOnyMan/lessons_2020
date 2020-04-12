using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectHealth : MonoBehaviour
{
    public DestroyableChair other;
    public Transform LookTarget;

    private Slider _heathBar;

    void Start()
    {
        _heathBar = GetComponent<Slider>();
    }

    void Update()
    {
        var current = other.Health / other.MaxHealth;
        _heathBar.value = current;
        transform.LookAt(transform.position + LookTarget.rotation * Vector3.forward, LookTarget.rotation * Vector3.up);
    }
}
