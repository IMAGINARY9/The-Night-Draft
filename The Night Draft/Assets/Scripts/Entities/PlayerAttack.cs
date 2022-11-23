using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerAttack : MonoBehaviour, IWeaponUser
    {
        [SerializeField] private Transform _weaponHolder;
        [SerializeField] private Weapon _weapon;

        public Weapon CurrentWeapon 
        { 
            get => _weapon; 
            set => _weapon = value; 
        }

        
        public Transform GetWeaponHolder() => _weaponHolder;

        public void Attack()
        {
            _weapon.Use();
        }


    }
}