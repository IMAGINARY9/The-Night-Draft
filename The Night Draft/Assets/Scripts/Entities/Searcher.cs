using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Searcher : MonoBehaviour
    {
        [SerializeField] protected string _targetTag = "Player";
        [SerializeField] private Raycast _vision;
        [SerializeField] private float _rayLenght;
        private float _visL;
        public Vector2 TargetPosition { get; private set; }

        private void Awake()
        {
            _visL = _rayLenght;
        }

        public bool Search(int sideCoeff)
        {
            var col = _vision.ColliderByTag(_visL * sideCoeff, _targetTag);
            if (col != null)
            {
                TargetPosition = col.transform.position;
                return true;
            }
            return false;
        }

    }
}