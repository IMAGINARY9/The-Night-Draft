using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class BonusShake : MonoBehaviour
    {
        [SerializeField] private float _moveTime;
        private int _dir; 
        private void Start()
        {
            _dir = 1;
            InvokeRepeating(nameof(ChangeDir), 0, _moveTime);
        }

        private void Update()
        {
            transform.localPosition += new Vector3(0, _dir) * (_moveTime * 0.1f) * Time.deltaTime;
        }

        private void ChangeDir() =>
            _dir = -_dir;
    }
}