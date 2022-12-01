using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IWeaponVisitor
    {
        public Color ParticlesColor { get; set; }
        public void Visit(Bullet bullet);
        public void Visit(Melee melee);
    }
}
