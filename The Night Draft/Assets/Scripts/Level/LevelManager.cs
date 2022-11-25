using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Bonus[] _bonuses;
        [SerializeField] private Transform _drop;
        private void Start()
        {
            BedsideTable.Drop += ChooseDrop;
        }

        private void ChooseDrop(Vector2 obj)
        {
            var rand = UnityEngine.Random.Range(0, _bonuses.Length);
            Instantiate(_bonuses[rand], obj, Quaternion.identity, _drop);
        }
    }
}