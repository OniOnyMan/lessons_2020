using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    public float ShootingForce = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shot();
        }
    }

    private void Shot() 
    {
        Instantiate(BulletPrefab, BulletSpawnPoint.position, Quaternion.identity)
            .GetComponent<BulletController>()
            .AddForce(BulletSpawnPoint.forward.normalized * ShootingForce);
        
    }
}
