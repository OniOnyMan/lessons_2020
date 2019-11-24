using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animator_afk
{
    public class PlayerController : MonoBehaviour
    {
        public float AfkTime = 5; 

        private Animator _animator;
        private float _timer;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (_timer < 0)
            {
                _timer = AfkTime;
            }
            else
            {
                _timer -= Time.deltaTime;
                _animator.SetFloat("AfkTime", _timer);

                if (_timer < 0)
                {
                    int idleType = Random.Range(0, 2);
                    _animator.SetInteger("IdleType", idleType);
                }
            }
        }
    }
}
