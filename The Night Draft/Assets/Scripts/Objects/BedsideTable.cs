using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BedsideTable : MonoBehaviour, IInteractive
    {
        public static Action<Vector2> Drop;
        [SerializeField] private Transform _dropPoint;

        public bool Used { get; set; }
        public void Use()
        {
            if (Used) return;
            Drop?.Invoke(_dropPoint.position);
            Used = true;
        }

    }
}