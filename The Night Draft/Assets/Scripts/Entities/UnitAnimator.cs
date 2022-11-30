using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class UnitAnimator : MonoBehaviour
    {
        static readonly int IdleAnim = Animator.StringToHash("Idle");
        static readonly int WalkAnim = Animator.StringToHash("Walk");
        static readonly int AttackAnim = Animator.StringToHash("Attack");
        
        [SerializeField] private Animator _animator;
        bool _stateIsLocked = false;
        int currentState;
        void Start()
        {
            Idle();
        }

        public void Idle() => SetState(IdleAnim);
        public void Attack()
        {
            SetState(AttackAnim);
            LockState(0.25f);
        }

        public void Move(float speed)
        {
            _animator.SetFloat("velocity", Mathf.Clamp(speed, 0.75f, 1));
            SetState(WalkAnim);
        }

        private void SetState(int state)
        {
            if (state != currentState && !_stateIsLocked)
            {
                _animator.CrossFade(state, 0, 0);
                currentState = state;
            }
        }
        private void LockState(float t)
        {
            _stateIsLocked = true;
            StartCoroutine(StateLockRoutine());
            IEnumerator StateLockRoutine()
            {
                yield return new WaitForSeconds(t);
                _stateIsLocked = false;
            }
        }
    }
}