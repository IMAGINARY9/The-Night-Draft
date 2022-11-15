using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : Unit
    {
        //[SerializeField] Joystick moveInput;
        [SerializeField] private PlayerMove _move;
        Vector2 _dir;
        private void FixedUpdate()
        {
            Input();
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
                _move.Move(_dir);
        }

        

    }
}