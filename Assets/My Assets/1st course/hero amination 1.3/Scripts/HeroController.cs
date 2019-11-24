using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace My_Animator
{
    public class HeroController : MonoBehaviour
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        void Start()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            float direction = Input.GetAxis("Horizontal");
            var rotation = transform.rotation;

            if (direction != 0)
            {
                if (direction < 0)
                {
                    //_spriteRenderer.flipX = true;
                    transform.rotation = Quaternion.Euler(rotation.x, 180, rotation.z);
                }
                else if (direction > 0)
                {
                    //_spriteRenderer.flipX = false;
                    transform.rotation = Quaternion.Euler(rotation.x, 0, rotation.z);
                }

                _animator.SetBool("Run", true);
            }
            else
            {
                _animator.SetBool("Run", false);
            }
        }
    }
}

