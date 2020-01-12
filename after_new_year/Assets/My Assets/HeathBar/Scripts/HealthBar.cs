using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private float _maximum;
    private float _current;
    private Transform _bar;

	// Use this for initialization
	void Start ()
    {
        _bar = transform.GetChild(0);
        _maximum = _bar.localScale.x;
        _current = _maximum;

        StartCoroutine(TimerSetValue());
	}

    private IEnumerator TimerSetValue()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            var persent = _current * 100 / _maximum;
            SetValue(persent - 5);
        }
    }

    public void SetValue(float persent)
    {
        if (persent >= 0 && persent <= 100)
        {
            _current = _maximum * persent / 100;
            _bar.localScale = new Vector3(_current, _bar.localScale.y);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
