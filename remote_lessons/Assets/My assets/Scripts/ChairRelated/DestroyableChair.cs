using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableChair : MonoBehaviour
{
    public float MaxHealth = 10;
    public GameObject DestryedPrefab;
    [Space]
    public bool IsCollision = false;
    public bool IsDying = true;
    public float DamagePerFrame = 0.01f;

    [SerializeField]
    private float _health;
    [SerializeField]
    private bool _isDead = false;

    public float Health 
    { 
        get => _health; 
        private set => _health = value; 
    }

    void Start()
    {
        _health = MaxHealth;
    }

    void Update()
    {
        if (IsDying)
        {
            GetDamage(DamagePerFrame);
        }
    }

    private void Die()
    {
        if (!_isDead)
        {
            _isDead = true;
            if (DestryedPrefab)
                Instantiate(DestryedPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (IsCollision)
        {
            var other = collision.gameObject;
            if (other.CompareTag("Bullet"))
            {
                GetDamage(other.GetComponent<BulletController>().Damage);
            }
        }
    }

    private void GetDamage(float damage) 
    {
        if (_health - damage > 0)
            _health -= damage;
        else
            Die();
    }
}
