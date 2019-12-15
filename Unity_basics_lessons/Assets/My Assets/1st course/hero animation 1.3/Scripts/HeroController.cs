using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace My_Animator
{
    public enum Direction
    {
        Left, Right
    }

    public class HeroController : MonoBehaviour
    {
        public bool RotateBySpriteRender = false;

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

            if (direction != 0)
            {
                if (direction < 0)
                {
                    SetDirection(Direction.Left);
                }
                else if (direction > 0)
                {
                    SetDirection(Direction.Right);
                }

                _animator.SetBool("Run", true);
            }
            else
            {
                _animator.SetBool("Run", false);
            }
        }

        private void SetDirection(Direction type)
        {
            var isLeft = type == Direction.Left;

            if (RotateBySpriteRender)
                _spriteRenderer.flipX = isLeft;
            else
            {
                var rotation = transform.rotation;
                var angle = isLeft ? 180 : 0;
                transform.rotation = Quaternion.Euler(rotation.x, angle, rotation.z);
            }
        }

        public void IsFalling(bool condition)
        {
            if (condition)
            {
                _animator.SetTrigger("Falling");
            }
            else
            {
                _animator.SetTrigger("Landing");
            }
        }

        public void Jump()
        {
            _animator.SetTrigger("Jump");
        }
    }
}

