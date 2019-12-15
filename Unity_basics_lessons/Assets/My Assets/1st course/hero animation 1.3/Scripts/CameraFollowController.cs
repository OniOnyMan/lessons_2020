using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public float ZLayerOrder = -10;

    private Transform _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Debug.Log(Input.mousePosition);
        gameObject.transform.position = new Vector3(_player.position.x, _player.position.y, ZLayerOrder);
    }
}
