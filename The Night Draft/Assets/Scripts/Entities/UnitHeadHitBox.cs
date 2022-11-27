using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class UnitHeadHitBox : UnitHitBox
    {
        public override void Visit(Bullet bullet)
        {
            print("head");
            unit.ApplyDamage(bullet.Damage * 2);
        }
    }
}