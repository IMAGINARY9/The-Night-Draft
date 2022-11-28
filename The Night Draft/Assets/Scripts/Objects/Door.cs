using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Door : MonoBehaviour, IInteractive
    {
        public bool Used { get; set; }
        private BoxCollider2D _col;
        private SpriteRenderer _sp;
        [SerializeField] private Sprite[] _sprites;
        private int _defaultLayer, _usedLayer;
        private void Start()
        {
            _col = GetComponent<BoxCollider2D>();
            _sp = GetComponent<SpriteRenderer>();
            _sp.sprite = _sprites[0];
            _defaultLayer = gameObject.layer;
            _usedLayer = LayerMask.NameToLayer("Used");
        }
        public void Use()
        {
            if (Used) Close();
            else Open();
            // Sound Event
        }

        private void Open()
        {
            Used = true;
            _col.isTrigger = true;
            _sp.sprite = _sprites[1];
            gameObject.layer = _usedLayer;
        }
        private void Close()
        {
            Used = false;
            _col.isTrigger = false;
            _sp.sprite = _sprites[0];
            gameObject.layer = _defaultLayer;

        }

    }
}