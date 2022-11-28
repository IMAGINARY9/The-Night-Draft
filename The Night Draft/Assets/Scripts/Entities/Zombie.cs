using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Zombie : Unit
    {
        [SerializeField] private Patrol _patrol;
        [SerializeField] private Searcher _searcher;
        [SerializeField] private MeleeAttack _attack;
        private bool IsAttack =>
            _searcher.Search(_patrol.IsRight ? 1 : -1);


        private void FixedUpdate()
        {
            if (IsAttack)
            {
                _patrol.Move(_searcher.TargetPosition.x
                    - transform.position.x);
                _attack.Attack();
            }
            else
                _patrol.Move();
        }

        protected override void Die()
        {
            base.Die();
            Destroy(gameObject);
        }
    }
}