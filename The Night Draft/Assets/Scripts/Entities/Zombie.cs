using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Zombie : Unit
    {
        [SerializeField] private Patrol _patrol;
        

        private void FixedUpdate()
        {
            _patrol.Move();
        }

        protected override void Die()
        {
            base.Die();
            Destroy(gameObject);
        }
    }
}