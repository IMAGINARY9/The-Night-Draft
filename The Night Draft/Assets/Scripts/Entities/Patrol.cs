using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private Overlap _wallCheck;
        [SerializeField] private Vector2 _reconsiderTime;
        private float _changeWayTime;
        private Rigidbody2D _rb;
        public int WalkDir { get; private set; }
        public bool IsRight { get; private set; }

        public bool IsObstacle => _wallCheck.IsCollided;
        void Awake()
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

        public void Move(float dir, float speed)
        {
            _rb.position += Vector2.right *
                dir * speed * 0.1f * Time.fixedDeltaTime;
        }

        public void Move(float speed)
        {
            if (IsObstacle)
                WalkDir = 0;

            if ((_changeWayTime -= Time.deltaTime) <= 0f)
            {
                ResetTimer();
                WalkDir = ChooseWay();
            }

            _rb.position += Vector2.right *
                WalkDir * speed * 0.1f * Time.fixedDeltaTime;

            if ((WalkDir > 0 && !IsRight)
                || (WalkDir < 0 && IsRight))
                Flip();

            void Flip()
            {
                IsRight = !IsRight;
                transform.Rotate(0, 180f, 0);
            }
        }


    }
}