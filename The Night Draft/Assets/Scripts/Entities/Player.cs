using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : Unit, IBonusCollector
    {
        //[SerializeField] Joystick moveInput;
        [SerializeField] private PlayerMove _move;
        [SerializeField] private PlayerAnimator _anim;
        [SerializeField] private PlayerAttack _attack;
        Vector2 _dir;
        public float Vertical => _dir.y;
        public CapsuleCollider2D Col { get; private set; }

        private void Start()
        {
            Col = GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.Space))
                _attack.Attack();
        }

        private void FixedUpdate()
        {
            Input();

            //if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            //{
            //    _attack.Attack();
            //}    


            var x = Mathf.Abs(_dir.x);
            if (x >= 0.01f)
                _anim.Move(x);
            else
                _anim.Idle();
        }
        private void Input()
        {
#if UNITY_ANDROID
            moveInput.x = h; moveInput.y = v;
#else
            _dir.x = UnityEngine.Input.GetAxis("Horizontal");
            _dir.y = UnityEngine.Input.GetAxis("Vertical");
#endif
            //if(_dir != Vector2.zero)
                _move.Move(_dir.x);
        }


    }
}