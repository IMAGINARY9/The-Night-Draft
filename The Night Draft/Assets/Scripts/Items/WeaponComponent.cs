using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponComponent : BonusComponent
    {
        Weapon defaultWeapon;
        Weapon thisWeapon;
        IWeaponUser user;
        public void SetWeapon(Weapon weapon, int ammo)
        {
            user = GetComponent<IWeaponUser>();
            defaultWeapon = user.CurrentWeapon;
            defaultWeapon.gameObject.SetActive(false);
            thisWeapon = Instantiate(weapon, user.GetWeaponHolder());
            thisWeapon.Ammo = ammo;
            thisWeapon.Over += OnBonusOver; 
            user.CurrentWeapon = thisWeapon;
        }
        protected override void OnBonusOver()
        {
            base.OnBonusOver();
            thisWeapon.Over -= OnBonusOver;
            Destroy(thisWeapon.gameObject);
            defaultWeapon.gameObject.SetActive(true);
            user.CurrentWeapon = defaultWeapon;
            Destroy(this);
        }

    }
}