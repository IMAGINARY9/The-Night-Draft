using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponBonus : Bonus
    {
        [SerializeField] private Sprite _weaponUI;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private int _ammo;
        public void SetAmmo(int count) => _ammo = count;

        protected override void OnCollected(GameObject collector)
        {
            var weaponUser = collector.GetComponent<IWeaponUser>();
            if (weaponUser == null) return;
            WeaponComponent currentWeapon = collector.GetComponent<WeaponComponent>();
            currentWeapon?.Deactivate();
            WeaponComponent newWeapon = collector.AddComponent<WeaponComponent>();
            newWeapon.SetWeapon(_weaponUI, _weapon, _ammo);

        }

    }
}