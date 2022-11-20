using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Gun : Weapon
    {
        [SerializeField] protected Bullet bullet;
        [SerializeField] protected Transform shootPoint;
        [SerializeField] private float _angle;
        [SerializeField] private float _minBulletDirectionModifier;
        [SerializeField] private float _maxBulletDirectionModifier;


        protected (Vector2, Quaternion) QuaternionCalc(float i)
        {
            Quaternion quaternion = Quaternion.Euler(0, 0, i - 1 * 0.5f + 0.5f);
            Quaternion positionRotation = quaternion;
            Quaternion directionRotation = quaternion;
            positionRotation.z *= _angle;
            var dirModifier = Random.Range(_minBulletDirectionModifier,
                                        _maxBulletDirectionModifier);
            directionRotation.z *= dirModifier * _angle;
            Vector2 pos = shootPoint.position + positionRotation * shootPoint.forward * 0.001f;
            return (pos, directionRotation);
        }
        protected override void OnUse()
        {
            base.OnUse();
            var offset = Random.Range(0f, 1f);
            Instantiate(bullet, QuaternionCalc(offset).Item1, shootPoint.rotation * QuaternionCalc(offset).Item2);
        }

    }
}