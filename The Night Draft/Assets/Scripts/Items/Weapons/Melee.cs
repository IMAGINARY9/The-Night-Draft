using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Melee : Weapon 
    {
        [SerializeField] private Overlap _damageZone;
        public int Damage => damage;
        //anim
        protected override void OnUse()
        {
            var col = _damageZone.Collider;
            if (col == null) return;
            if (col.TryGetComponent<IWeaponVisitor>(out var visitor))
                visitor.Visit(this);
        }

    }
}