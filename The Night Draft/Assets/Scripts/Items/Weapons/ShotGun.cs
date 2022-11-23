using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShotGun : Gun
    {
        [SerializeField, Range(1, 10)] private int _bulletCount;
        

        protected override void OnUse()
        {
            base.OnUse();
            for (int i = 0; i < _bulletCount; i++)
            {
                Instantiate(bullet, QuaternionCalc(i).Item1,
                    shootPoint.rotation * QuaternionCalc(i).Item2);
            }
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; i < _bulletCount; i++)
                Gizmos.DrawWireSphere(QuaternionCalc(i).Item1, 0.005f);
        }
    }
}