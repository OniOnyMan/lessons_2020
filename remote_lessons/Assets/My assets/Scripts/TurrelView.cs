using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelView : MonoBehaviour
{
    private Transform _target;
    private bool _drawLine;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<OnTriggerEvent>().OnTriggered += OnTurrelTriggered;
    }

    // Update is called once per frame
    void Update()
    {
        if (_drawLine)
        {
            Debug.DrawLine(transform.position, _target.position, Color.red);
        }
    }

    private void OnTurrelTriggered(bool condition, GameObject sender) 
    {
        if (condition)
        {
            Debug.LogWarning($"Detected {sender.name}");
            RaycastHit hit;
            if (Physics.Linecast(transform.position, sender.transform.position, out hit))
            {
                Debug.LogWarning($"Fallow {hit.transform.name}");
                _target = sender.transform;
                _drawLine = true;
            }
        }
        else 
        {
            Debug.LogWarning($"Lost {sender.name}");
            _drawLine = false;
            _target = null;
        }
    }
}
