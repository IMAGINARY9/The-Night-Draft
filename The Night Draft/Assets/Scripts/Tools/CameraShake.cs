
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraShake : MonoBehaviour
    {
        private static CameraShake instance;
        private Vector3 _originalPos;
        private void Awake()
        {
            instance = this;
            _originalPos = transform.localPosition;
        }

        public static void Shake(float duration, float magnitude)
        {
            instance.StartCoroutine(instance.ShakeRoutine(duration, magnitude));
        }

        IEnumerator ShakeRoutine(float duration, float magnitude)
        {
            float elapsed = 0.0f;
            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, y, _originalPos.y);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = _originalPos;
        }
    }
}