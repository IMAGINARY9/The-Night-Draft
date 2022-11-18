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
        //private float _speed;
        private float _horizontal;
        private float _gravity;
        public float Movement { get; private set; }
        public bool IsRight { get; private set; }

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            //_speed = _maxSpeed;
            IsRight = true;
            _gravity = _rb.gravityScale;
        }

        public void Move(float dir) 
        {
            _horizontal = dir;
            Rotate();
            Friction();
            Run();

            CheckStairs();
        }
        private void CheckStairs()
        {
            if (_stairsCheck.IsCollided && _horizontal == 0)
                _rb.gravityScale = 0;
            else
                _rb.gravityScale = _gravity;
        }
        
        private void Run()
        {
            float targetSpeed = _horizontal * _speed;
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

            if ((_horizontal > 0 && !IsRight) || (_horizontal < 0 && IsRight))
                Flip();

            void Flip()
            {
                IsRight = !IsRight;
                transform.Rotate(0, 180f, 0);
            }
        }

    }
}