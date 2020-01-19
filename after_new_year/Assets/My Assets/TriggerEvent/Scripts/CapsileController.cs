using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsileController : MonoBehaviour
{
    public int DelayAttack = 3;
    public int Speed = 10;
    public float StopMoving = 5;

    private Transform _player;
    private bool _isMoving = false;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        for (int i = 0; i < transform.childCount; i++)
        {
            var childFieldView = transform.GetChild(i).GetComponent<CapsuleTriggersControllers>();
            if (childFieldView.name == "MovingView")
            {
                childFieldView.EventOnTriggerEnter += MoveToPlayer;
            }
            else if(childFieldView.name == "AttackView")
            {
                childFieldView.EventOnTriggerEnter += AttackPlayer;
            }
        }
    }

    void Update()
    {
        if (_isMoving)
        {
            MoveToTarget(_player.position);
        }
    }

    public void MoveToPlayer(bool condition, GameObject sender)
    {
        _isMoving = condition;
    }

    public void AttackPlayer(bool condition, GameObject sender)
    {
        _isMoving = !condition;
        if (condition)
        {
            StartCoroutine(AttackOnTime());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator AttackOnTime()
    {
        while (true)
        {
            ShotPlayer();
            yield return new WaitForSecondsRealtime(DelayAttack);
        }
    }

    private void ShotPlayer()
    {
        Debug.Log("Player shooted");
    }

    //public void PlayerFound()
    //{
    //    _isMoving = true;
    //}

    //public void PlayerLost()
    //{
    //    _isMoving = false;
    //}

    private void MoveToTarget(Vector3 target)
    {
        var heading = target - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        transform.Translate(direction * Speed * Time.deltaTime);

    }
}
