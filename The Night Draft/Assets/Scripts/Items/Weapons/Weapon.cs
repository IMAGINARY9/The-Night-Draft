using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private float rechargeTime;
        [SerializeField] private WeaponBonus _reserv;
        public WeaponBonus Reserv => _reserv;
        public int Ammo { get; set; }
        //[SerializeField] protected AudioSource useSound;
        public Action Over;

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
        protected virtual void OnUse() 
        {
            if (--Ammo <= 0)
                Over?.Invoke();
        } // => useSound?.Play();
    }
}