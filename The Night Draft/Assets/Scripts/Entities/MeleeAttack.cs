using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MeleeAttack : MonoBehaviour
    {
        [SerializeField] private Overlap _checkDist;
        [SerializeField] private Weapon _weapon;
        public Action Attacking;
        public void Attack()
        {
            if(_checkDist.IsCollided)
            {
                Attacking?.Invoke();
                StartCoroutine(WaitRoutine());
                IEnumerator WaitRoutine()
                {
                    yield return new WaitForSeconds(0.25f);
                    _weapon.Use();
                }
            }
        }
    }
}