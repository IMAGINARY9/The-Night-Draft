using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Zombie : Unit
    {
        
        protected override void Die()
        {
            base.Die();
            Destroy(gameObject);
        }
    }
}