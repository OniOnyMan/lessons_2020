using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent Agent;

    private Vector3 _lastTargetPos;

    private void Awake()
    {
        _lastTargetPos = Target.position;
    }

    void Start()
    {
        if(!Agent)
            Agent = GetComponent<NavMeshAgent>();
        Move();
    }

    void Update()
    {
        if (_lastTargetPos != Target.position) 
        {
            _lastTargetPos = Target.position;
            Move();
        }
    }

    private void Move()
    {
        if(Agent)
            Agent.SetDestination(_lastTargetPos);
    }
}
