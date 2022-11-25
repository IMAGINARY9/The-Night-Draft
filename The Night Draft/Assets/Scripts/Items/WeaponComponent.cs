using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponComponent : BonusComponent
    {
        public static Action<WeaponBonus, Vector2, int> WeaponEjection;
        private Weapon _defaultWeapon;
        private Weapon _thisWeapon;
        private IWeaponUser _user;
        public void SetWeapon(Weapon weapon, int ammo)
        {
            _user = GetComponent<IWeaponUser>();
            _defaultWeapon = _user.CurrentWeapon;
            _defaultWeapon.gameObject.SetActive(false);
            _thisWeapon = Instantiate(weapon, _user.GetWeaponHolder());
            _thisWeapon.Ammo = ammo;
            _thisWeapon.Over += OnBonusOver; 
            _user.CurrentWeapon = _thisWeapon;
        }
        protected override void OnBonusOver()
        {
            base.OnBonusOver();
            _thisWeapon.Over -= OnBonusOver;
            Destroy(_thisWeapon.gameObject);
            _defaultWeapon.gameObject.SetActive(true);
            _user.CurrentWeapon = _defaultWeapon;
            Destroy(this);
        }

        //public override void Deactivate()
        //{
        //    if(thisWeapon.Ammo > 0)
        //        //DropCurrentWeapon?.Invoke(transform.position)
        //        Instantiate(thisWeapon, transform.position, Quaternion.identity, LevelManager.Drop).Ammo = thisWeapon.Ammo;
        //    base.Deactivate();
        //}
        public override void Deactivate()
        {
            if (_thisWeapon.Ammo > 0)
            {
                WeaponEjection?.Invoke(_thisWeapon.Reserv, transform.position, _thisWeapon.Ammo);
                //var weapon = Instantiate(_thisWeapon.Reserv, 
                //    transform.position, Quaternion.identity, LevelManager.Drop);
                //weapon.SetAmmo(_thisWeapon.Ammo);
            }
            base.Deactivate();
        }
    }
}