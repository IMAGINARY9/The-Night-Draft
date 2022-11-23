using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;

        void Start()
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            Destroy(gameObject, lifeTime);
            //LevelManager.Restart += OnRestart;
        }
        //void OnDestroy() => LevelManager.Restart -= OnRestart;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(tag)) return;
            Destroy(gameObject);
            //damage
        }
    }
}