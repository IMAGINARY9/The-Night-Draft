using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Gun : Weapon
    {
        [SerializeField] protected Bullet bullet;
        [SerializeField] protected Transform shootPoint;
        [SerializeField] protected WeaponObject stats;
        [SerializeField] protected ParticleSystem particle;
        
        protected (Vector2, Quaternion) QuaternionCalc(float i)
        {
            Quaternion quaternion = Quaternion.Euler(0, 0, i - 1 * 0.5f + 0.5f);
            Quaternion positionRotation = quaternion;
            Quaternion directionRotation = quaternion;
            positionRotation.z *= stats.Angle;
            var dirModifier = Random.Range(stats.BulletDirectionModifier.x,
                                        stats.BulletDirectionModifier.y);
            directionRotation.z *= dirModifier * stats.Angle;
            Vector2 pos = shootPoint.position + positionRotation * shootPoint.forward * 0.001f;
            return (pos, directionRotation);
        }
        protected override void OnUse()
        {
            base.OnUse();
            particle.Play();
            CameraShake.Shake(0.05f, stats.Recoil);
            var offset = Random.Range(0f, 1f);
            Instantiate(bullet,
                QuaternionCalc(offset).Item1,
                shootPoint.rotation * QuaternionCalc(offset).Item2).Damage = damage;
        }
    }
}