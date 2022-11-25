using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Bonus[] _bonuses;
        [SerializeField] private Transform _drop;
        private void Start()
        {
            BedsideTable.Drop += ChooseDrop;
            WeaponComponent.WeaponEjection += InstantiateWeapon;
        }

        private void ChooseDrop(Vector2 pos)
        {
            var rand = UnityEngine.Random.Range(0, _bonuses.Length);
            Instantiate(_bonuses[rand], pos, Quaternion.identity, _drop);
        }
        private void InstantiateWeapon(WeaponBonus obj, Vector2 pos, int ammo)
        {
            Instantiate(obj, pos, Quaternion.identity, _drop).SetAmmo(ammo);
        }
    }
}