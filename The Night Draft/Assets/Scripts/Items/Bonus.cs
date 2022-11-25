using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bonus : MonoBehaviour
    {
        public static event Action<Vector2> BonusCollected; //particles
        
        protected virtual void OnCollected(GameObject collector) { }

        private void OnTriggerStay2D(Collider2D col)
        {
            if(col.TryGetComponent<IBonusCollector>(out var collector))
            {
                if (!collector.ReadyToTake) return;
                OnCollected(col.gameObject);
                BonusCollected?.Invoke(transform.position);
                Destroy(gameObject);
                collector.ReadyToTake = false;
            }
        }

    }
}