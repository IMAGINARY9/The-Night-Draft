using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponComponent : BonusComponent
    {
        public static Action<WeaponBonus, Vector2, int> WeaponEjection;
        public static Action<Sprite> WeaponUIUpdate;
        private Weapon _defaultWeapon;
        private Weapon _thisWeapon;
        private IWeaponUser _user;
        public void SetWeapon(Sprite weaponUI, Weapon weapon, int ammo)
        {
            _user = GetComponent<IWeaponUser>();
            _defaultWeapon = _user.CurrentWeapon;
            _defaultWeapon.gameObject.SetActive(false);
            _thisWeapon = Instantiate(weapon, _user.GetWeaponHolder());
            _thisWeapon.Ammo = ammo;
            _thisWeapon.Over += OnBonusOver; 
            _user.CurrentWeapon = _thisWeapon;
            WeaponUIUpdate?.Invoke(weaponUI);
        }
        protected override void OnBonusOver()
        {
            base.OnBonusOver();
            _thisWeapon.Over -= OnBonusOver;
            Destroy(_thisWeapon.gameObject);
            _defaultWeapon.gameObject.SetActive(true);
            _user.CurrentWeapon = _defaultWeapon;
            WeaponUIUpdate?.Invoke(null);
            Destroy(this);
        }
        public override void Deactivate()
        {
            if (_thisWeapon.Ammo > 0)
                WeaponEjection?.Invoke(_thisWeapon.Reserv, transform.position, _thisWeapon.Ammo);
            base.Deactivate();
        }
    }
}