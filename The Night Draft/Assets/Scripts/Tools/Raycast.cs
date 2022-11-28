using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Raycast : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        Vector2 rayDir = Vector2.right;
        public RaycastHit2D Hit(float visionLenght)
        {
            Debug.DrawRay(transform.position, rayDir * visionLenght, Color.yellow);
            return Physics2D.Raycast(transform.position, Vector2.right, visionLenght, _layerMask);
        }

        public Collider2D ColliderByTag(float visionLenght, string tag)
        {
            Debug.DrawRay(transform.position, rayDir * visionLenght, Color.red);
            var hit = Physics2D.Raycast(transform.position, Vector2.right, visionLenght, _layerMask);
            if (hit.collider != null)
                if (hit.collider.CompareTag(tag))
                    return hit.collider;
            return null;
        }
    }
}