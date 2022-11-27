using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerAttack : MonoBehaviour, IWeaponUser
    {
        public Action WeaponChanged;
        [SerializeField] private Transform _weaponHolder;
        [SerializeField] private Weapon _weapon;

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
            _weapon.Use();
        }


    }
}