using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        [SerializeField] private ParticleSystem _destroyParticles;
        public int Damage { get; set; }

        void Start()
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * _speed;
            Destroy(gameObject, _lifeTime);
        }

        [Obsolete]
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.CompareTag(tag)) return;
            Destroy(gameObject);

            var particle = Instantiate(_destroyParticles, transform.position, Quaternion.identity);

            if(col.collider.TryGetComponent<IWeaponVisitor>(out var visitor))
            {
                visitor.Visit(this);
                particle.startColor = visitor.ParticlesColor;
            }

            particle.Play();
            Destroy(particle.gameObject, particle.startLifetime);

        }
    }
}