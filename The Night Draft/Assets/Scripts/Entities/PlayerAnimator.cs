using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerAnimator : MonoBehaviour
    {
        static readonly int IdleAnim = Animator.StringToHash("Idle");
        static readonly int WalkAnim = Animator.StringToHash("Walk");

        [SerializeField] private Animator _animator;
        int currentState;
        void Start()
        {
            Idle();
        }

        public void Idle() => SetState(IdleAnim);

        public void Move(float speed)
        {
            _animator.SetFloat("velocity", Mathf.Clamp(speed, 0.75f, 100));
            SetState(WalkAnim);
        }

        private void SetState(int state)
        {
            if (state != currentState)
            {
                _animator.CrossFade(state, 0, 0);
                currentState = state;
            }
        }
    }
}