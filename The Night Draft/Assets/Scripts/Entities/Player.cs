using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : Unit, IBonusCollector
    {
        //[SerializeField] Joystick _moveInput;
        [SerializeField] private PlayerMove _move;
        [SerializeField] private UnitAnimator _anim;
        [SerializeField] private PlayerAttack _attack;
        [SerializeField] private Overlap _objectCheck;
        Vector2 _dir;
        public float Vertical => _dir.y;
        public CapsuleCollider2D Col { get; private set; }
        public bool ReadyToTake { get; set; }
        public bool IsAttacking { get; set; }

        public static event Action PlayerDied;

        private void Start()
        {
            Col = GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            if (Confused) return;
            //if (IsAttacking)
            if (Input.GetKey(KeyCode.Space))
            {
                _attack.Attack();
                _anim.Attack();
                Confuse(0.15f);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(TakingRoutine());


                var obj = _objectCheck.Collider;
                if (obj != null)
                    if (obj.TryGetComponent<IInteractive>(out var foundObject))
                        foundObject.Use();

            }
        }
        //public void Interactive()
        //{
        //    if (Confused) return;

        //    StartCoroutine(TakingRoutine());
        //    var obj = _objectCheck.Collider;
        //    if (obj != null)
        //        if (obj.TryGetComponent<IInteractive>(out var foundObject))
        //            foundObject.Use();

        //}

        private void FixedUpdate()
        {
            if (Confused) return;
            MoveInput();

            var x = Mathf.Abs(_dir.x);
            if (x >= 0.01f)
                _anim.Move(x);
            else
                _anim.Idle();
        }
        private void MoveInput()
        {
#if UNITY_ANDROID
            _dir.x = _moveInput.Horizontal; 
            var v = _moveInput.Vertical;
            if (v >= 0.25f || v <= -0.25f)
                _dir.y = v;
            else
                _dir.y = 0;
#else
            _dir.x = Input.GetAxis("Horizontal");
            _dir.y = Input.GetAxis("Vertical");
#endif
            //if(_dir != Vector2.zero)
            _move.Move(_dir.x);

        }

        IEnumerator TakingRoutine()
        {
            ReadyToTake = true;
            yield return new WaitForFixedUpdate();
            ReadyToTake = false;
        }
        public override void ApplyDamage(int damage)
        {
            base.ApplyDamage(damage);
            LightFlicker.Flicker(0.75f, 1f);
        }
        protected override void Die()
        {
            base.Die();
            PlayerDied?.Invoke();
        }
    }
}