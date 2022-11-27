using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{
    public class UIProvider : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _ammo;
        [SerializeField] private Image _weaponImage;
        [SerializeField] private Bar _healthBar;
        [SerializeField] private Unit _player;
        [SerializeField] private PlayerAttack _playerWeapon;
        private Weapon _currentWeapon;
        void Start()
        {
            _playerWeapon.WeaponChanged += UpdateWeapon;
            WeaponComponent.WeaponUIUpdate += UpdateWeaponIcon;
            _player.HPChanged += UpdateHP;
            UpdateHP(_player.HP);
        }

        private void UpdateWeapon()
        {
            if(_currentWeapon != null)
                _currentWeapon.AmmoChanged -= UpdateAmmo;

            _currentWeapon = _playerWeapon.CurrentWeapon;
            _currentWeapon.AmmoChanged += UpdateAmmo;
            UpdateAmmo(_currentWeapon.Ammo);
        }

        private void UpdateAmmo(int value) =>
            _ammo.text = value.ToString();

        private void UpdateWeaponIcon(Sprite sprite)
        {
            if (sprite == null)
                _weaponImage.enabled = false;
            else
            {
                _weaponImage.sprite = sprite;
                _weaponImage.enabled = true;
            }
            
        }

        private void UpdateHP(int value) =>
            _healthBar.Set(value);

    }
}