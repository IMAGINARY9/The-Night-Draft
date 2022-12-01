using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : Unit, IBonusCollector
    {
        //[SerializeField] Joystick moveInput;
        [SerializeField] private PlayerMove _move;
        [SerializeField] private UnitAnimator _anim;
        [SerializeField] private PlayerAttack _attack;
        [SerializeField] private Overlap _objectCheck;
        Vector2 _dir;
        public float Vertical => _dir.y;
        public CapsuleCollider2D Col { get; private set; }
        public bool ReadyToTake { get; set; }

        private void Start()
        {
            Col = GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            if (Confused) return;
            if (Input.GetKey(KeyCode.Space))
                _attack.Attack();
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(TakingRoutine());


                var obj = _objectCheck.Collider;
                if (obj != null)
                    if (obj.TryGetComponent<IInteractive>(out var foundObject))
                        foundObject.Use();

            }
        }

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
            moveInput.x = h; moveInput.y = v;
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

        
    }
}