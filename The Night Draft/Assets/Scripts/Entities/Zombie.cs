using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Zombie : Unit
    {
        [SerializeField] private Searcher _searcher;
        [SerializeField] private MeleeAttack _attack;
        [SerializeField] private UnitAnimator _animator;
        [SerializeField] private Patrol _patrol;
        [SerializeField] private float _walkSpeed;
        private float _speed;
        private bool IsAttack =>
            _searcher.Search(_patrol.IsRight ? 1 : -1);

        protected override void Awake()
        {
            base.Awake();
            ResetSpeed();
            _attack.Attacking += OnAttack;
        }

        private void OnAttack() => _animator.Attack();
        private void ResetSpeed() => _speed = _walkSpeed;

        private void FixedUpdate()
        {
            if (Confused) { Stop(); return; }
            if (IsAttack)
            {
                _speed = _walkSpeed * 4;
                _patrol.Move(_searcher.TargetPosition.x
                    - transform.position.x, _speed);
                _attack.Attack();
            }
            else
            {
                ResetSpeed();
                _patrol.Move(_speed);
            }

            if (_patrol.WalkDir != 0 || IsAttack)
                _animator.Move(_speed);
            else
                Stop();
        }
        private void Stop()
        {
            _animator.Idle();
        }

        protected override void Die()
        {
            base.Die();
            _attack.Attacking -= OnAttack;
            Destroy(gameObject);
        }
    }
}