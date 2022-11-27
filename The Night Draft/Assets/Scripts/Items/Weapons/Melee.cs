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
            if (_damageZone.Collider.TryGetComponent<IWeaponVisitor>(out var visitor))
                visitor.Visit(this);
        }

    }
}