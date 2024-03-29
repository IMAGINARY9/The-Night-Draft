﻿using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Zombie : Unit
    {
        [SerializeField] private Searcher _searcher;
        [SerializeField] private ZombieAttack _attack;
        [SerializeField] private UnitAnimator _animator;
        [SerializeField] private Patrol _patrol;
        [SerializeField] private float _walkSpeed;
        private float _speed;
        public bool IsAlive { get; private set; }
        private bool IsAttack =>
            _searcher.Search(_patrol.IsRight ? 1 : -1);

        public Action<Zombie> Died;

        protected override void Awake()
        {
            base.Awake();
            ResetSpeed();
            IsAlive = true;
            _attack.Attacking += OnAttack;
        }

        private void OnAttack() => _animator.Attack();
        private void ResetSpeed() => _speed = _walkSpeed;

        private void FixedUpdate()
        {
            if (!IsAlive) return;
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
            Died?.Invoke(this);
            _attack.Attacking -= OnAttack;
            IsAlive = false;
            _animator.Die();
            Destroy(gameObject, 0.75f);
        }
    }
}