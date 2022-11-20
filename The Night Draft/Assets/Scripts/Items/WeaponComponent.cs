using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponComponent : BonusComponent
    {
        Weapon defaultWeapon;
        Weapon thisWeapon;
        IWeaponUser user;

        public void SetWeapon(Weapon weapon)
        {
            user = GetComponent<IWeaponUser>();
            defaultWeapon = user.CurrentWeapon;
            defaultWeapon.gameObject.SetActive(false);
            thisWeapon = Instantiate(weapon, user.GetWeaponHolder());
            user.CurrentWeapon = thisWeapon;
        }
        protected override void OnBonusOver()
        {
            base.OnBonusOver();
            Destroy(thisWeapon.gameObject);
            defaultWeapon.gameObject.SetActive(true);
            user.CurrentWeapon = defaultWeapon;
            Destroy(this);
        }

    }
}