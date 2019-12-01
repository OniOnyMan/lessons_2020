using System.Linq;
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
            _timer = AfkTime;
        }

        void Update()
        {
            AfkTimerTick();
        }

        public void OnAfkAnimationEnd()
        {
            _timer = AfkTime;
            _animator.SetBool("IsAfk", false);
        }

        private void AfkTimerTick()
        {
            if (!_animator.GetBool("IsAfk"))
            {
                if (_timer > 0)
                {
                    _timer -= Time.deltaTime;
                    _animator.SetFloat("AfkTime", _timer);
                }
                else
                {
                    int idleType = Random.Range(0, 2);
                    _animator.SetInteger("IdleType", idleType);
                    _animator.SetBool("IsAfk", true);
                }
            }
        }
    }
}
