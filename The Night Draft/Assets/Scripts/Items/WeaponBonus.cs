using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponBonus : Bonus
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private int _ammo;

        protected override void OnCollected(GameObject collector)
        {
            var weaponUser = collector.GetComponent<IWeaponUser>();
            if (weaponUser == null) return;
            WeaponComponent currentWeapon = collector.GetComponent<WeaponComponent>();
            currentWeapon?.Deactivate();
            WeaponComponent newWeapon = collector.AddComponent<WeaponComponent>();
            newWeapon.SetWeapon(_weapon, _ammo);
            //newWeapon.Activate(_ammo);

        }

    }
}