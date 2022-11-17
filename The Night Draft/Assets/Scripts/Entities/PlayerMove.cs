using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private Overlap _stairsCheck;


        [Header("Run")]
        [SerializeField] private int _speed; 
        [SerializeField] private int _acceleration; 
        [SerializeField] private int _decceleration; 
        [SerializeField] private float _velPower; 
        [SerializeField] private float _frictionAmount;
        private Rigidbody2D _rb;
        public CapsuleCollider2D Col { get; private set; }
        //private float _speed;
        private Vector2 _dir;
        private float _gravity;
        public float Movement { get; private set; }
        public bool IsRight { get; private set; }
        public float DirY => _dir.y;

        private void Start()
        {
            Col = GetComponent<CapsuleCollider2D>();
            _rb = GetComponent<Rigidbody2D>();
            //_speed = _maxSpeed;
            IsRight = true;
            _gravity = _rb.gravityScale;
            
        }

        public void Move(Vector2 dir)
        {
            _dir = dir;
            Rotate();
            Friction();
            Run();

            CheckStairs();
        }
        private void CheckStairs()
        {
            if (_stairsCheck.IsCollided && _dir.x == 0)
                _rb.gravityScale = 0;
            else
                _rb.gravityScale = _gravity;
        }
        
        private void Run()
        {
            float targetSpeed = _dir.x * _speed;
            float speedDif = targetSpeed - _rb.velocity.x;
            float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? _acceleration : _decceleration;
            Movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, _velPower) * Mathf.Sign(speedDif);

            _rb.AddForce(Movement * Vector2.right);
        }
        private void Friction()
        {
            float amount = Mathf.Min(Mathf.Abs(_rb.velocity.x), Mathf.Abs(_frictionAmount));
            amount *= Mathf.Sign(_rb.velocity.x);
            _rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        }
        void Rotate()
        {

            if ((_dir.x > 0 && !IsRight) || (_dir.x < 0 && IsRight))
                Flip();

            void Flip()
            {
                IsRight = !IsRight;
                transform.Rotate(0, 180f, 0);
            }
        }

    }
}