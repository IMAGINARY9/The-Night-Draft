using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private Overlap _wallCheck;
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _reconsiderTime;
        private float _changeWayTime;
        private int _walkDir;
        private Rigidbody2D _rb;
        public bool IsRight { get; private set; }

        public bool IsObstacle => _wallCheck.IsCollided;
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            ResetTimer();
            IsRight = true;
        }
        private void ResetTimer() => _changeWayTime 
            = Random.Range(_reconsiderTime.x, _reconsiderTime.y);

        private int ChooseWay()
        {
            if (IsObstacle && IsRight)
                return -1;
            else if (IsObstacle && !IsRight)
                return 1;
            else
                return Random.Range(-1, 2);
        }

        public void Move()
        {
            if (IsObstacle)
                _walkDir = 0;

            if ((_changeWayTime -= Time.deltaTime) <= 0f)
            {
                ResetTimer();
                _walkDir = ChooseWay();
            }

            _rb.position += Vector2.right *
                _walkDir * _speed * 0.1f * Time.fixedDeltaTime;

            if ((_walkDir > 0 && !IsRight)
                || (_walkDir < 0 && IsRight))
                Flip();

            void Flip()
            {
                IsRight = !IsRight;
                transform.Rotate(0, 180f, 0);
            }
        }


    }
}