using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private float rechargeTime;
        //[SerializeField] protected AudioSource useSound;

        private bool _canUse;

        private void OnEnable()
        {
            _canUse = true;
        }

        public void Use()
        {
            if (!_canUse) return;
            OnUse();
            StartCoroutine(UsageManagingRoutine());
            IEnumerator UsageManagingRoutine()
            {
                _canUse = false;
                yield return new WaitForSeconds(rechargeTime);
                _canUse = true;
            }
        }
        
        protected virtual void OnUse() { } // => useSound?.Play();
    }
}