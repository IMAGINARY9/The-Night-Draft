using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;
        public int Damage { get; set; }

        void Start()
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            Destroy(gameObject, lifeTime);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.CompareTag(tag)) return;
            Destroy(gameObject);

            if(col.collider.TryGetComponent<IWeaponVisitor>(out var visitor))
                visitor.Visit(this);
        }
    }
}