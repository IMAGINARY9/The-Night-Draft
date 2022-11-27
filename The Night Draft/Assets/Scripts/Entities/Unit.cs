using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Unit : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _hp;

        public int HP { get; private set; }
        public event Action<int> HPChanged;

        private void Awake()
        {
            HP = _hp;
        }

        public void ApplyDamage(int damage)
        {
            if ((HP -= Mathf.Max(damage, 1)) <= 0)
                Die();
            HPChanged?.Invoke(HP);
        }

        protected virtual void Die() { }

    }
}
    