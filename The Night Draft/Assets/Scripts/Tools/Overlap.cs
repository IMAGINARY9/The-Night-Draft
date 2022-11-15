using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Overlap : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _radius;

        public Collider2D Collider =>
             Physics2D.OverlapCircle(transform.position, _radius, _layerMask);
    

        public bool IsCollided =>
             Physics2D.OverlapCircle(transform.position, _radius, _layerMask);

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}