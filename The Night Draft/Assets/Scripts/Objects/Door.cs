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
        [SerializeField] private Sprite[] sprites;
        private void Start()
        {
            _col = GetComponent<BoxCollider2D>();
            _sp = GetComponent<SpriteRenderer>();
            _sp.sprite = sprites[0];
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
            _sp.sprite = sprites[1];
        }
        private void Close()
        {
            Used = false;
            _col.isTrigger = false;
            _sp.sprite = sprites[0];

        }

    }
}