using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Unit : MonoBehaviour, IDamageable, IHealable
    {
        [SerializeField] private int _hp;

        public bool Confused { get; private set; }
        public int HP { get; private set; }
        public Action<int> HPChanged;

        protected virtual void Awake()
        {
            Confused = false;
            HP = _hp;
        }

        public virtual void ApplyDamage(int damage)
        {
            if ((HP -= Mathf.Max(damage, 1)) <= 0)
                Die();
            HPChanged?.Invoke(HP);
        }
        public virtual void ApplyHeal()
        {
            if (++HP > _hp)
                HP = _hp;
            HPChanged?.Invoke(HP);
        }
        public void Confuse(float time)
        {
            Confused = true;
            StartCoroutine(ConfuseRoutine());
            IEnumerator ConfuseRoutine()
            {
                yield return new WaitForSeconds(time);
                Confused = false;
            }
        }


        protected virtual void Die() { }

    }
}
    