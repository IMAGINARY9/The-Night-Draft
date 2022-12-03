using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Bonus[] _bonuses;
        [SerializeField] private List<Zombie> _zombies;
        [SerializeField] private Transform _drop;
        public static event Action GameOver;
        private void Start()
        {
            BedsideTable.Drop += ChooseDrop;
            WeaponComponent.WeaponEjection += InstantiateWeapon;
            PauseMenu.GameRestart += Restart;

            foreach (var zombie in _zombies)
                zombie.Died += Eliminate;
        }

        private void Eliminate(Zombie zombie)
        {
            zombie.Died -= Eliminate;
            _zombies.Remove(zombie);
            if(_zombies.Count == 0)
                GameOver?.Invoke();
        }

        private void Restart()
        {
            foreach (Transform item in _drop)
                Destroy(item.gameObject);

            BedsideTable.Drop -= ChooseDrop;
            WeaponComponent.WeaponEjection -= InstantiateWeapon;
            PauseMenu.GameRestart -= Restart;

            foreach (var zombie in _zombies)
                zombie.Died -= Eliminate;
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