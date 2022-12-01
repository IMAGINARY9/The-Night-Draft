using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class UnitHitBox : MonoBehaviour, IWeaponVisitor
    {
        [SerializeField] protected Unit unit;
        [SerializeField] protected Color particlesColor;
        public Color ParticlesColor { get; set; }

        private void Start()
        {
            ParticlesColor = particlesColor;
        }
        public virtual void Visit(Bullet bullet)
        {
            print("body");
            unit.ApplyDamage(bullet.Damage);
        }

        public void Visit(Melee melee)
        {
            print("body");
            //confuse
            unit.ApplyDamage(melee.Damage);
        }
    }
}