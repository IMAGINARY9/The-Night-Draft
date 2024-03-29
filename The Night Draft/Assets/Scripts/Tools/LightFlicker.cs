﻿using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts
{
    public class LightFlicker : MonoBehaviour
    {
        private static LightFlicker instance;
        private Light2D _light;
        private float _originalIntensity;
        private void Awake()
        {
            instance = this;
            _light = GetComponent<Light2D>();
            _originalIntensity = _light.intensity;
        }

        public static void Flicker(float duration, float magnitude)
        {
            instance.StartCoroutine(instance.FlickerRoutine(duration, magnitude));
        }

        IEnumerator FlickerRoutine(float duration, float magnitude)
        {
            float elapsed = 0.0f;
            float max = _light.intensity + magnitude;
            while (elapsed < duration)
            {
                 _light.intensity = Random.Range(0, max);

                elapsed += Time.deltaTime;
                yield return null;
            }
            _light.intensity = _originalIntensity;
        }
    }
}