using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerAttack : MonoBehaviour, IWeaponUser
    {
        [SerializeField] private Transform _weaponHolder;
        [SerializeField] private Weapon _weapon;
        public Action WeaponChanged;

        public Weapon CurrentWeapon 
        { 
            get => _weapon;
            set
            {
                _weapon = value;
                WeaponChanged?.Invoke();
            }
        }
        public Transform GetWeaponHolder() => _weaponHolder;
        public void Attack()
        {
            StartCoroutine(WaitRoutine());
            IEnumerator WaitRoutine()
            {
                yield return new WaitForSeconds(0.12f);
                _weapon.Use();
            }
        }

    }
}